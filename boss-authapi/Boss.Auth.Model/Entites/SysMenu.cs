using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Boss.Auth.Model.Entites
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("SysMenu")]
    public class SysMenu
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public int Id { get; set; }
        /// <summary>
        /// 应用Code 
        ///</summary>
         [SugarColumn(ColumnName="AppCode"    )]
         public string AppCode { get; set; }
        /// <summary>
        /// 菜单名称 
        ///</summary>
         [SugarColumn(ColumnName="MenuName"    )]
         public string MenuName { get; set; }
        /// <summary>
        /// 父菜单Id(0表示是根菜单) 
        /// 默认值: 0
        ///</summary>
         [SugarColumn(ColumnName="ParentId"    )]
         public int ParentId { get; set; }
        /// <summary>
        /// 菜单图标 
        ///</summary>
         [SugarColumn(ColumnName="MenuIcon"    )]
         public string MenuIcon { get; set; }
        /// <summary>
        /// 路由地址
        ///</summary>
        [SugarColumn(ColumnName = "Path")]
        public string Path { get; set; }
        /// <summary>
        /// 菜单Url 
        ///</summary>
        [SugarColumn(ColumnName="MenuUrl"    )]
         public string MenuUrl { get; set; }
        /// <summary>
        /// 菜单类型(1目录 2页面 3按钮) 
        ///</summary>
         [SugarColumn(ColumnName="MenuType"    )]
         public int? MenuType { get; set; }
        /// <summary>
        /// 菜单权限标识 
        ///</summary>
         [SugarColumn(ColumnName="Authorize"    )]
         public string Authorize { get; set; }
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
