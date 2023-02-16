using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.User
{
    public class GetInfoDto
    {
        public List<string> Permissions { set; get; }

        public List<string> Roles { set; get; }

        public UserInfoDto User { set; get; }
    }
}
