using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Dict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Services
{
    public class DictService: BaseService, IDictService
    {
        public DictService()
        {

        }
        /// <summary>
        /// 根据类型获取字典列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<ResponseDto<List<DictDataDto>>> GetDictData(string type)
        {
            var dic = InitDicData();
            dic.TryGetValue(type, out var data);
            return Success<List<DictDataDto>>(data);
        }

        private Dictionary<string, List<DictDataDto>> InitDicData()
        {
            var dic = new Dictionary<string, List<DictDataDto>>();
            dic.Add("sys_normal_disable", new List<DictDataDto>()
            {
                new DictDataDto(){ Default=true,DictCode=1,DictLabel="正常",DictSort=1,DictType="sys_normal_disable",DictValue="1",IsDefault="Y",ListClass="primary"},
                new DictDataDto(){Default=false,DictCode=2,DictLabel="停用",DictSort=2,DictType="sys_normal_disable",DictValue="0",IsDefault="N",ListClass="danger"}
            });
            return dic;
        }
    }
}
