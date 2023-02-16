using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Dict;
using Microsoft.AspNetCore.Mvc;

namespace Boss.Auth.WebApi.Controllers
{
    /// <summary>
    /// 字典数据
    /// </summary>
    public class DictController: BaseController
    {
        private readonly IDictService _dictService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictService"></param>
        public DictController(IDictService dictService)
        {
            _dictService=dictService;
        }
        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDictData")]
        [ProducesResponseType(typeof(ResponseDto<List<DictDataDto>>), 200)]
        public async Task<ActionResult> GetDictData(string type)
        {
            var result = await _dictService.GetDictData(type);
            return Ok(result);
        }
    }
}
