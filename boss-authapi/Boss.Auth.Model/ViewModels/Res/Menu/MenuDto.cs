using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.Menu
{
    public class MenuDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 应用Code 
        ///</summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 菜单名称 
        ///</summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 父菜单Id(0表示是根菜单) 
        /// 默认值: 0
        ///</summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 菜单图标 
        ///</summary>
        public string MenuIcon { get; set; }
        /// <summary>
        /// 路由地址
        /// </summary>
        public string Path { set; get; }
        /// <summary>
        /// 菜单Url 
        ///</summary>
        public string MenuUrl { get; set; }
        /// <summary>
        /// 菜单类型(1目录 2页面 3按钮) 
        ///</summary>
        public string MenuType { get; set; }
        /// <summary>
        /// 菜单权限标识 
        ///</summary>
        public string Authorize { get; set; }
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
        /// 创建时间 
        ///</summary>
        public DateTime CreateTime { get; set; }
    }
}
