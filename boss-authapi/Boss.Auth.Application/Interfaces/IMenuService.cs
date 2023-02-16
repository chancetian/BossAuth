using Boss.Auth.Model.ViewModels.Req.Menu;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Auth.Model.ViewModels.Res.Menu;

namespace Boss.Auth.Application.Interfaces
{
    public interface IMenuService
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<List<MenuDto>>> GetMenuList(GetMenuListReq req);
        /// <summary>
        /// 获取部门树形结构数据
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto<List<TreeDto>>> GetMenuTreeList(string appCode);
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDto<MenuDto>> QueryMenuByID(int id);
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> AddMenu(MenuReq req);
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> UpdateMenu(MenuReq req);
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> DeleteMenu(int id);

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto<List<int>>> GetRoleMenus(GetRoleMenusReq model);


    }
}
