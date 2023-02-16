using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.Role
{
    public class RoleDto
    {
        public int Id { set;get;}

        public string RoleName { set;get;}

        public int Sort { set;get;}

        public int Status { set;get;}

        public string CreateTime { set; get; }
        /// <summary>
        /// ≤Àµ•id¡–±Ì
        /// </summary>
        public List<int> MenuIds { get; set; }
    }
}