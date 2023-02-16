using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.AppSecret
{
    public class AppSecretDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 应用Id 
        ///</summary>
        public string AppId { get; set; }
        /// <summary>
        /// 应用密钥 
        ///</summary>
        public string AppSecret { get; set; }
        /// <summary>
        /// 应用Code(唯一值) 
        ///</summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 应用名 
        ///</summary>
        public string AppName { get; set; }
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
