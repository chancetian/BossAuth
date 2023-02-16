using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Boss.Auth.Common.Extensions;
using System.IdentityModel.Tokens.Jwt;

namespace Boss.Auth.Application.Helper
{

    public static class HttpCurrentContext
    {
        private static IHttpContextAccessor _accessor;

        public static HttpContext Current => _accessor.HttpContext;

        public static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        /// <summary>
        /// 配置测试用户
        /// </summary>
        public static void SetTestUser(Dictionary<string, string> dic)
        {

            var claims = new List<Claim>() { };
            foreach (KeyValuePair<string, string> kv in dic)
            {
                claims.Add(new Claim(kv.Key, kv.Value));
            }
            var claimsIdentity = new ClaimsIdentity(claims.ToArray());
            Current.User = new ClaimsPrincipal(claimsIdentity);
        }
        /// <summary>
        /// IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIp
        {
            get
            {
                var ip = Current.Request.Headers["X-Forwarded-For"].FirstOrDefault();
                if (string.IsNullOrEmpty(ip))
                {
                    ip = Current.Connection.RemoteIpAddress.ToString();
                }
                return ip;
            }
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        public static JwtUserInfo GetUserInfo
        {
            get
            {
                return Current.User.GetToken();
            }
        }
        /// <summary>
        /// 获取 User Token
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <returns></returns>
        public static JwtUserInfo GetToken(this ClaimsPrincipal claimsPrincipal)
        {
            var claims = claimsPrincipal.Claims;
            var userToken = new JwtUserInfo
            {
                Id = claims.GetClaimsValue(JwtRegisteredClaimNames.Jti).ToInt(),
                UserName = claims.GetClaimsValue(ClaimTypes.Name),
                RoleId = claims.GetClaimsValue(ClaimTypes.Role).ToInt(),
                AppCode = claims.GetClaimsValue("AppCode"),
                Data=claims.GetClaimsValue(ClaimTypes.UserData)
            };
            return userToken;
        }
        ///<summary>
        /// 获取 Claims Value
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetClaimsValue(this IEnumerable<Claim> claims, string type)
        {
            return claims.FirstOrDefault(t => t.Type == type)?.Value ?? "";
        }
    }  
    /// <summary>
    /// 
    /// </summary>
    public static class StaticHttpContextExtensions
    {
        /// <summary>
        /// 配置HttpContext
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseStaticHttpContext(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpCurrentContext.Configure(httpContextAccessor);
            return app;
        }
    }
 

}
