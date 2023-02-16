using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Infrastructure.Authentication
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method,AllowMultiple =true)]
    public class PermissionAuthorize:Attribute, IAsyncAuthorizationFilter
    {
        public string AuthCode { set; get; }

        public PermissionAuthorize(string authCode)
        {
            AuthCode=authCode;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var isDefined = false;
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                   .Any(a => a.GetType().Equals(typeof(AllowAnonymousAttribute)));
            }
            if (isDefined) return;

            var claimsPrincipal = context.HttpContext.User;

            if (!claimsPrincipal.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new ChallengeResult();
                return;
            }
            var authorizationService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
            var authorizationResult = await authorizationService.AuthorizeAsync(claimsPrincipal, null, new PermissionAuthorizationRequirement(AuthCode));
            if (!authorizationResult.Succeeded)
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
                return;
            }
        }
    }
}
