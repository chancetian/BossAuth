using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Req.AppSecret
{
    public class GetAppSecretPageListReq:Page
    {
        /// <summary>
        /// 应该名称
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; } = -1;
    }
}
