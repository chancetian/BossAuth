using Boss.Auth.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Domain.Interfaces.Menu
{
    public interface IMenuAuthDomainService : IBaseDomainService<SysMenuAuth>
    {
        /// <summary>
        /// 删除菜单权限
        /// </summary>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        Task<int> DeletMenuAuth(int authorizeId, int authorizeType, string appCode = "");
        /// <summary>
        /// 获取角色菜单
        /// </summary>
        /// <param name="appCode"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<int>> GetRoleMenuIds(string appCode, int roleId);
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="appCode"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<SysMenu>> GetMenuList(string appCode, int roleId);
        /// <summary>
        /// 获取角色授权标识列表
        /// </summary>
        /// <param name="appCode"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<string>> GetMenuAuthData(string appCode, int roleId);
    }
}
