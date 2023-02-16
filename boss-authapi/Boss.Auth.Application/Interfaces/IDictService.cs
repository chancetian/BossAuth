using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Dict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Interfaces
{
    public interface IDictService
    {
        /// <summary>
        /// 根据类型获取字典列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<ResponseDto<List<DictDataDto>>> GetDictData(string type);
    }
}
