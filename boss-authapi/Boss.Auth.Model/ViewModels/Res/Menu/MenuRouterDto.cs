using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.Menu
{
    public class MenuRouterDto
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Data> data { get; set; }
    }
    public class Meta
    {
        /// <summary>
        /// 系统管理
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool noCache { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
    }
    public class Children
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool hidden { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string component { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Meta meta { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool hidden { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string redirect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string component { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool alwaysShow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Meta meta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Children> children { get; set; }
    }


}
