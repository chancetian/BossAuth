using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.Department
{
    public class DepartmentInfoDto
    {   /// <summary>
        ///  
        ///</summary>
        public int Id { get; set; }
        /// <summary>
        /// 部门名称 
        ///</summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 父部门Id(0表示是根部门) 
        ///</summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 电话/手机 
        ///</summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 邮箱 
        ///</summary>
        public string Email { get; set; }
        /// <summary>
        /// QQ 
        ///</summary>
        public string Qq { get; set; }
        /// <summary>
        /// 负责人
        ///</summary>
        public string Leader { get; set; }
        /// <summary>
        /// 状态(1:启用;0禁用) 
        /// 默认值: 1
        ///</summary>
        public string Status { get; set; }
        /// <summary>
        /// 创建时间 
        ///</summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间 
        ///</summary>
        public DateTime? ModifyTime { get; set; }
    }
}
