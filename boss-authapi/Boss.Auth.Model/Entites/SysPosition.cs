using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Boss.Auth.Model.Entites
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("SysPosition")]
    public class SysPosition
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public int Id { get; set; }
        /// <summary>
        /// 职位名称 
        ///</summary>
         [SugarColumn(ColumnName="PositionName"    )]
         public string PositionName { get; set; }
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
