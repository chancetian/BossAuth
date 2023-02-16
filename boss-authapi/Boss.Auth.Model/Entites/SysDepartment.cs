using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Boss.Auth.Model.Entites
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("SysDepartment")]
    public class SysDepartment
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public int Id { get; set; }
        /// <summary>
        /// 部门名称 
        ///</summary>
         [SugarColumn(ColumnName="DepartmentName"    )]
         public string DepartmentName { get; set; }
        /// <summary>
        /// 父部门Id(0表示是根部门) 
        ///</summary>
         [SugarColumn(ColumnName="ParentId"    )]
         public int ParentId { get; set; }
        /// <summary>
        /// 电话/手机 
        ///</summary>
         [SugarColumn(ColumnName="Telephone"    )]
         public string Telephone { get; set; }
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
        /// 负责人
        ///</summary>
         [SugarColumn(ColumnName= "Leader")]
         public string Leader { get; set; }
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
