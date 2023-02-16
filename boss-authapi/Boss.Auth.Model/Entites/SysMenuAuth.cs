using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Boss.Auth.Model.Entites
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("SysMenuAuth")]
    public class SysMenuAuth
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public int Id { get; set; }
        /// <summary>
        /// 菜单Id 
        ///</summary>
         [SugarColumn(ColumnName="MenuId"    )]
         public int MenuId { get; set; }
        /// <summary>
        /// 授权Id(角色Id或者用户Id) 
        ///</summary>
         [SugarColumn(ColumnName="AuthorizeId"    )]
         public int AuthorizeId { get; set; }
        /// <summary>
        /// 授权类型(1角色 2用户) 
        ///</summary>
         [SugarColumn(ColumnName="AuthorizeType"    )]
         public int? AuthorizeType { get; set; }
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
    }
}
