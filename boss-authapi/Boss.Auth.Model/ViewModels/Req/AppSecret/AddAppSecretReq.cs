using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Req.AppSecret
{
    public class AddAppSecretReq
    {
        /// <summary>
        /// 应用Code
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { get; set; }
    }
    public class SysAppSecretReq
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { get; set; }
    }
     
}
