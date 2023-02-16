using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Req.Role;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Role;
using Boss.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boss.Auth.WebApi.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleService"></param>
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:role:add")]
        public async Task<ActionResult> Post([FromBody] AddOrUpdateRoleReq req)
        {
            var result = await _roleService.Add(req);
            return Ok(result);
        }
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:role:edit")]
        public async Task<ActionResult> Put([FromBody] AddOrUpdateRoleReq req)
        {
            var result = await _roleService.Update(req);
            return Ok(result);
        }
        /// <summary>
        /// 查看角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseDto<RoleDto>), 200)]
        [PermissionAuthorize("system:role:view")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _roleService.QueryByID(id);
            return Ok(result);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:role:remove")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _roleService.Delete(id);
            return Ok(result);
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPageList")]
        [ProducesResponseType(typeof(ResponseDto<PageDto<RoleDto>>), 200)]
        [PermissionAuthorize("system:role:list")]
        public async Task<ActionResult> GetPageList([FromBody] GetRolePageListReq req)
        {
            var result = await _roleService.GetPageList(req);
            return Ok(result);
        }
    }
}