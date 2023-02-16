using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.Dict
{
    public class DictDataDto
    {
        /// <summary>
        /// 是否默认
        /// </summary>
       public bool Default { set; get; }
        /// <summary>
        /// 字典值
        /// </summary>
        public int DictCode { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string DictLabel { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int DictSort { set; get; }
        /// <summary>
        /// 类型
        /// </summary>
        public string DictType { set; get; }
        /// <summary>
        /// 值
        /// </summary>
        public string DictValue { set; get; }
        /// <summary>
        /// 是否默认
        /// </summary>
        public string IsDefault { set; get; }
        /// <summary>
        /// 样式
        /// </summary>
        public string ListClass { set; get; }
    }
}
