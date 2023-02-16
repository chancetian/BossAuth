using Boss.Auth.Common.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Helper
{
    public class JwtUserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int RoleId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string RoleName { set; get; }
        /// <summary>
        /// app应用code
        /// </summary>
        public string AppCode { set; get; }
        /// <summary>
        /// 扩展数据JSON字符串
        /// </summary>
        public string Data { set; get; } = "";
    }
    public class JwtHelper
    {
        public bool IsRefreshToken(string token)
        {
            var claimsPrincipal = GetClaimsPrincipalByAccessToken(token);
            if (claimsPrincipal == null)
            {
                throw new Exception($"解析token失败({token})");
            }
            var expTimestamp = claimsPrincipal.Claims.ToList().Where(p => p.Type == "exp")?.FirstOrDefault()?.Value;

            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));//当地时区
            var expTime = startTime.AddSeconds(Convert.ToDouble(expTimestamp));

            long minutes = (long)(expTime - DateTime.Now).TotalMinutes;
            if (minutes <= 3) //小于3分钟时提醒刷新token
            {
                return true;
            }
            return false;
        }

        public ClaimsPrincipal GetClaimsPrincipalByAccessToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            try
            {
                return handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingsHelper.GetContent<string>("JwtConfig", "SecretKey"))),
                    ValidateLifetime = false
                }, out SecurityToken validatedToken);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string CreateToken(JwtUserInfo info)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, info.UserName),
            new Claim(ClaimTypes.Role, info.RoleId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, info.Id.ToString()),
            new Claim("AppCode",info.AppCode),
            new Claim(ClaimTypes.UserData,info.Data)
            
        };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingsHelper.GetContent<string>("JwtConfig", "SecretKey")));

            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(secretKey, algorithm);

            var jwtSecurityToken = new JwtSecurityToken(
                AppSettingsHelper.GetContent<string>("JwtConfig", "Issuer"),     //Issuer
                AppSettingsHelper.GetContent<string>("JwtConfig", "Audience"),   //Audience
                claims,                          //Claims,
                DateTime.Now,                    //notBefore
                DateTime.Now.AddMinutes(AppSettingsHelper.GetContent<int>("JwtConfig", "TokenExpiration")),    //expires
                signingCredentials               //Credentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
