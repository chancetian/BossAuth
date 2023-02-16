using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Req
{
    public class Page
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageNum { get; set; } = 1;
        /// <summary>
        /// 每页显示多少条
        /// </summary>
        public int PageSize { get; set; } = 10;
    }

    public class SearchTimeModel
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public string BeginTime { set; get; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { set; get; }
    }
}
