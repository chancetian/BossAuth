using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.Position
{
    public class PositionDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 职位名称 
        ///</summary>
        public string PositionName { get; set; }
        /// <summary>
        /// 备注 
        ///</summary>
        public string Remark { get; set; }
        /// <summary>
        /// 排序 
        ///</summary>
        public int? Sort { get; set; }
        /// <summary>
        /// 状态(1:启用;0禁用) 
        /// 默认值: 1
        ///</summary>
        public string Status { get; set; }
        /// <summary>
        /// 创建人姓名
        ///</summary>
        public string CreatorUserName { get; set; }
        /// <summary>
        /// 创建时间 
        ///</summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间 
        ///</summary>
        public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 修改人姓名
        ///</summary>
        public int? ModifierUserName { get; set; }
    }
}
