

using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Req.Department;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Department;
using Boss.Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Boss.Auth.WebApi.Controllers
{
    /// <summary>
    /// 部门管理
    /// </summary>
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentService"></param>
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        /// <summary>
        /// 获取树形结构部门信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTreeSelect")]
        [ProducesResponseType(typeof(ResponseDto<List<DepartmentTreeDto>>), 200)]
        [PermissionAuthorize("system:dept:list")]
        public async Task<ActionResult> GetTreeSelectList()
        {
            var result = await _departmentService.GetDepartmentTreeList();
            return Ok(result);
        }
        /// <summary>
        /// 获取部门数据列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetList")]
        [ProducesResponseType(typeof(ResponseDto<List<DepartmentDto>>), 200)]
        [PermissionAuthorize("system:dept:list")]
        public async Task<ActionResult> GetDepartmentList([FromBody] GetDepartmentListReq req)
        {
            var result = await _departmentService.GetDepartmentList(req);
            return Ok(result);
        }
        /// <summary>
        ///获取部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseDto<DepartmentInfoDto>), 200)]
        [PermissionAuthorize("system:dept:view")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _departmentService.QueryByID(id);
            return Ok(result);
        }
        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:dept:add")]
        public async Task<ActionResult> Post([FromBody] AddOrUpdateDepatmentReq req)
        {
            var result = await _departmentService.Add(req);
            return Ok(result);
        }
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto<bool>), 200)]
        [PermissionAuthorize("system:dept:edit")]
        public async Task<ActionResult> Put([FromBody] AddOrUpdateDepatmentReq req)
        {
            var result = await _departmentService.Update(req);
            return Ok();
        }
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:dept:remove")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _departmentService.Delete(id);
            return Ok(result);
        }
    }
}
