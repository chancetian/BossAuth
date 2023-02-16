using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Req.User
{
    public class GetUserPageListReq : Page
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { set; get; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { set; get; }=-1;
        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepartmentId { set; get; } = -1;
        /// <summary>
        /// 查询时间范围
        /// </summary>
        public SearchTimeModel Params { set; get; }

    }
}
