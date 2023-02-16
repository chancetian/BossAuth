using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Boss.Auth.Model.Entites
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("SysUser")]
    public class SysUser
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public int Id { get; set; }
        /// <summary>
        /// 登录名 
        ///</summary>
         [SugarColumn(ColumnName="UserName"    )]
         public string UserName { get; set; }
        /// <summary>
        /// 密码 
        ///</summary>
         [SugarColumn(ColumnName="Password"    )]
         public string Password { get; set; }
        /// <summary>
        /// 密码加盐 
        ///</summary>
         [SugarColumn(ColumnName="Salt"    )]
         public string Salt { get; set; }
        /// <summary>
        /// 真实姓名 
        ///</summary>
         [SugarColumn(ColumnName="RealName"    )]
         public string RealName { get; set; }
        /// <summary>
        /// 部门 
        ///</summary>
         [SugarColumn(ColumnName="DepartmentId"    )]
         public int? DepartmentId { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        [SugarColumn(ColumnName = "PositionId")]
        public int? PositionId { get; set; }
        /// <summary>
        /// 性别(1:男 0:女) 
        ///</summary>
         [SugarColumn(ColumnName="Sex"    )]
         public int? Sex { get; set; }
        /// <summary>
        /// 生日 
        ///</summary>
         [SugarColumn(ColumnName="Birthday"    )]
         public string Birthday { get; set; }
        /// <summary>
        /// 头像 
        ///</summary>
         [SugarColumn(ColumnName="Portrait"    )]
         public string Portrait { get; set; }
        /// <summary>
        /// 手机 
        ///</summary>
         [SugarColumn(ColumnName="Mobile"    )]
         public string Mobile { get; set; }
        /// <summary>
        /// 邮箱  
        ///</summary>
         [SugarColumn(ColumnName="Email"    )]
         public string Email { get; set; }
        /// <summary>
        /// QQ 
        ///</summary>
         [SugarColumn(ColumnName="QQ"    )]
         public string Qq { get; set; }
        /// <summary>
        /// 微信 
        ///</summary>
         [SugarColumn(ColumnName="WeChat"    )]
         public string WeChat { get; set; }
        /// <summary>
        /// 是否超级管理员(1:是 0:否) 
        /// 默认值: 0
        ///</summary>
         [SugarColumn(ColumnName="IsAdmin"    )]
         public byte? IsAdmin { get; set; }
        /// <summary>
        /// 备注 
        ///</summary>
         [SugarColumn(ColumnName="Remark"    )]
         public string Remark { get; set; }
        /// <summary>
        /// 排序 
        ///</summary>
         [SugarColumn(ColumnName="Sort"    )]
         public int? Sort { get; set; }
        /// <summary>
        /// 否已删除 
        /// 默认值: 0
        ///</summary>
         [SugarColumn(ColumnName="IsDeleted"    )]
         public byte IsDeleted { get; set; }
        /// <summary>
        /// 状态(1:启用;0禁用) 
        /// 默认值: 1
        ///</summary>
         [SugarColumn(ColumnName="Status"    )]
         public int Status { get; set; }
        /// <summary>
        /// 创建人Id 
        ///</summary>
         [SugarColumn(ColumnName="CreatorId"    )]
         public int? CreatorId { get; set; }
        /// <summary>
        /// 创建时间 
        ///</summary>
         [SugarColumn(ColumnName="CreateTime"    )]
         public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间 
        ///</summary>
         [SugarColumn(ColumnName="ModifyTime"    )]
         public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 修改人Id 
        ///</summary>
         [SugarColumn(ColumnName="ModifierId"    )]
         public int? ModifierId { get; set; }
    }
}
