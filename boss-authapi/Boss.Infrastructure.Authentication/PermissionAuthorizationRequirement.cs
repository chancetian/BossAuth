using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Infrastructure.Authentication
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public string AuthCode { set; get; }
        public PermissionAuthorizationRequirement(string authCode)
        {
            AuthCode = authCode;
        }
    }
}
