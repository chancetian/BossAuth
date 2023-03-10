using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Req.User
{
    public class AddUserReq
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 登录名 
        ///</summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码 
        ///</summary>
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名 
        ///</summary>
        public string RealName { get; set; }
        /// <summary>
        /// 部门 
        ///</summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// 性别(1:男 0:女) 
        ///</summary>
        public int? Sex { get; set; }
        /// <summary>
        /// 生日 
        ///</summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 头像 
        ///</summary>
        public string Portrait { get; set; }
        /// <summary>
        /// 手机 
        ///</summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱  
        ///</summary>
        public string Email { get; set; }
        /// <summary>
        /// QQ 
        ///</summary>
        public string Qq { get; set; }
        /// <summary>
        /// 微信 
        ///</summary>
        public string WeChat { get; set; }
        /// <summary>
        /// 是否超级管理员(1:是 0:否) 
        /// 默认值: 0
        ///</summary>
        public byte? IsAdmin { get; set; }
        /// <summary>
        /// 备注 
        ///</summary>
        public string Remark { get; set; }
        /// <summary>
        /// 排序 
        ///</summary>
        public int? Sort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 岗位id列表
        /// </summary>
        public int PostIds { get; set; }
        /// <summary>
        /// 角色id列表
        /// </summary>
        public int RoleIds { get; set; }
    }
}
