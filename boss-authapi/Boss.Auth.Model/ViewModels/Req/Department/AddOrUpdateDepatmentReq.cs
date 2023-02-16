using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Req.Department
{
    public class AddOrUpdateDepatmentReq
    {
        /// <summary>
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
        /// </summary>
        public string Leader { set;get; }
    }
}
