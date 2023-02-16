using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Infrastructure.Authentication
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        public PermissionAuthorizationHandler()
        {

        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            var authCode = requirement.AuthCode;
            if (context.User != null)
            {
                if (context.User.IsInRole("1"))//admin
                {
                    context.Succeed(requirement);
                }
                else
                {
                    var userIdClaim = context.User.FindFirst(_ => _.Type == ClaimTypes.NameIdentifier);
                    var userData = context.User.FindFirst(_ => _.Type == ClaimTypes.UserData) == null ? "" : context.User.FindFirst(_ => _.Type == ClaimTypes.UserData).ToString();
                    if (!string.IsNullOrEmpty(userData))
                    {
                        if (userData.Contains(authCode))
                        {
                            context.Succeed(requirement);
                            return Task.CompletedTask;
                        }
                        else
                        {
                            context.Fail();
                        }
                    }
                    context.Fail();
                }
            }
            return Task.CompletedTask;
        }
    }
}
