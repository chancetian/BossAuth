using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Req.Position;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Position;
using Boss.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boss.Auth.WebApi.Controllers
{
    /// <summary>
    /// 职位管理
    /// </summary>
    public class PositionController : BaseController
    {
        private readonly IPositionService _positionService;
       /// <summary>
       /// 
       /// </summary>
       /// <param name="positionService"></param>
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        /// <summary>
        /// 添加职位信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:post:add")]
        public async Task<ActionResult> Post([FromBody] AddOrUpdatePositionReq req)
        {
            var result = await _positionService.Add(req);
            return Ok(result);
        }
        /// <summary>
        /// 修改职位信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:post:edit")]
        public async Task<ActionResult> Put([FromBody] AddOrUpdatePositionReq req)
        {
            var result = await _positionService.Update(req);
            return Ok(result);
        }
        /// <summary>
        /// 查看职位信息详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseDto<PositionDto>), 200)]
        [PermissionAuthorize("system:post:view")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _positionService.QueryByID(id);
            return Ok(result);
        }
        /// <summary>
        /// 删除职位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:post:remove")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _positionService.Delete(id);
            return Ok(result);
        }
        /// <summary>
        /// 获取职位信息列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetList")]
        [ProducesResponseType(typeof(ResponseDto<PageDto<PositionDto>>), 200)]
        [PermissionAuthorize("system:post:list")]
        public async Task<ActionResult> GetList([FromBody] PositionListReq req)
        {
            var result = await _positionService.GetList(req);
            return Ok(result);
        }
    }
}
