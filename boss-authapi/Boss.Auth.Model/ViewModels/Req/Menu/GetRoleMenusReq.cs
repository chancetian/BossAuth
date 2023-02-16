using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Req.Menu
{
    /// <summary>
    /// 
    /// </summary>
    public class GetRoleMenusReq
    {
        /// <summary>
        /// app应用
        /// </summary>
        public string AppCode { set; get; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { set; get; }
    }
}
