using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Req.Role
{
    public class GetRolePageListReq : Page
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; } = -1;
        /// <summary>
        /// 查询时间范围
        /// </summary>
        public SearchTimeModel Params { set; get; }
    }
}
