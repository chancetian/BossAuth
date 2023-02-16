using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res
{
    public class ResponseDto<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public ResponseCode Code { set; get; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { set; get; } = "";
        /// <summary>
        /// Data
        /// </summary>
        public T Data { set; get; }
    }

    public class PageDto<T>
    {
        /// <summary>
        /// 当前页面索引
        /// </summary>
        public int PageNum { get; set; }

        /// <summary>
        /// 页面数据数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 全部数据总数
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// 页面总数
        /// </summary>
        public int PageCount
        {
            get
            {
                return PageSize > 0 ? (int)Math.Ceiling((double)Total / PageSize) : 0;
            }
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        public List<T> List { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public PageDto(int pageIndex, int pageSize)
        {
            PageNum = pageIndex;
            PageSize = pageSize;
        }

    }

    public enum ResponseCode
    {
        Success = 0,
        Fail = 1,
        GlobalExption = 500
    }
}
