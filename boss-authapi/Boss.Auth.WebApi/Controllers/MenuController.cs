using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Req;
using Boss.Auth.Model.ViewModels.Req.Menu;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.Entites;
using Microsoft.AspNetCore.Mvc;
using Boss.Auth.Model.ViewModels.Res.Menu;
using Boss.Auth.Application.Helper;
using Microsoft.AspNetCore.Authorization;
using Boss.Infrastructure.Authentication;

namespace Boss.Auth.WebApi.Controllers
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public class MenuController : BaseController
    {
       
        private readonly IMenuService  _menuService;
         /// <summary>
         /// 
         /// </summary>
         /// <param name="menuService"></param>
        public MenuController(IMenuService  menuService)
        {
            _menuService = menuService;
        }
        /// <summary>
        /// 获取树形结构菜单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTreeSelect")]
        [ProducesResponseType(typeof(ResponseDto<List<TreeDto>>), 200)]
        [PermissionAuthorize("system:menu:list")]
        public async Task<ActionResult> GetTreeSelectList(string appCode)
        {
            var result = await _menuService.GetMenuTreeList(appCode);
            return Ok(result);
        }
        /// <summary>
        /// 获取菜单数据列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetList")]
        [ProducesResponseType(typeof(ResponseDto<List<MenuDto>>), 200)]
        [PermissionAuthorize("system:menu:list")]
        public async Task<ActionResult> GetMenuList([FromBody] GetMenuListReq req)
        {
              var result = await _menuService.GetMenuList(req);
            return Ok(result);
        }
        /// <summary>
        /// 查看菜单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseDto<MenuDto>), 200)]
        [PermissionAuthorize("system:menu:view")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _menuService.QueryMenuByID(id);
            return Ok(result);
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:menu:add")]
        public async Task<ActionResult> Post([FromBody] MenuReq req)
        {
            var result = await _menuService.AddMenu(req);
            return Ok(result);
        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:menu:edit")]
        public async Task<ActionResult> Put([FromBody] MenuReq req)
        {
            var result = await _menuService.UpdateMenu(req);
            return Ok(result);
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:menu:remove")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _menuService.DeleteMenu(id);
            return Ok(result);
        }
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetRoleMenus")]     
        [ProducesResponseType(typeof(ResponseDto<List<int>>), 200)]
        public async Task<ActionResult> GetRoleMenus(GetRoleMenusReq rq)
        {
            var result = await _menuService.GetRoleMenus(rq);
            return Ok(result);
        }
    }
}
