using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Req.Position
{
    public class AddOrUpdatePositionReq
    {
        public int Id { get; set; }

        public string PositionName { get; set; }

        public int Sort { get; set; }

        public int Status { get; set; }

        public string Remark { get; set; }
    }


    public class PositionListReq: Page
    {
        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// 状态(1:启用;0:禁用)
        /// </summary>
        public int Status { set; get; } = -1;
    }
}
