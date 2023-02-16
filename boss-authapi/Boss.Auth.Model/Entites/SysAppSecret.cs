using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Boss.Auth.Model.Entites
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("SysAppSecret")]
    public class SysAppSecret
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public int Id { get; set; }
        /// <summary>
        /// 应用Id 
        ///</summary>
         [SugarColumn(ColumnName="AppId"    )]
         public string AppId { get; set; }
        /// <summary>
        /// 应用密钥 
        ///</summary>
         [SugarColumn(ColumnName="AppSecret"    )]
         public string AppSecret { get; set; }
        /// <summary>
        /// 应用Code(唯一值) 
        ///</summary>
         [SugarColumn(ColumnName="AppCode"    )]
         public string AppCode { get; set; }
        /// <summary>
        /// 应用名 
        ///</summary>
         [SugarColumn(ColumnName="AppName"    )]
         public string AppName { get; set; }
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
