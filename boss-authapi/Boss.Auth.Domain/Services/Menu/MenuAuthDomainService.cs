using Boss.Auth.Domain.Interfaces.Menu;
using Boss.Auth.Model.Entites;
using Boss.Auth.Model.Enum;
using Boss.Auth.Repository.Interfaces;
using Boss.Auth.Repository.Interfaces.Menu;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Domain.Services.Menu
{
    public class MenuAuthDomainService : BaseDomainService<SysMenuAuth>, IMenuAuthDomainService
    {
        private readonly IMenuAuthRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MenuAuthDomainService(IUnitOfWork unitOfWork,
            IMenuAuthRepository repository)
        {
            this._repository = repository;
            base._baseRepository = repository;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 删除菜单权限
        /// </summary>
        /// <param name="authorizeId"></param>
        /// <param name="authorizeType"></param>
        /// <param name="appCode"></param>
        /// <returns></returns>
        public async Task<int> DeletMenuAuth(int authorizeId, int authorizeType, string appCode = "")
        {
            var db = _unitOfWork.GetDbClient();
            string strSql = @"DELETE  from SysMenuAuth where AuthorizeId=@authorizeId and AuthorizeType=@authorizeType";
            var paramList = new List<SugarParameter>
            {
                  new SugarParameter("@authorizeId",authorizeId,System.Data.DbType.Int32),
                  new SugarParameter("@authorizeType",authorizeType,System.Data.DbType.Int32)
            };
            if (!string.IsNullOrEmpty(appCode))
            {
                strSql = @"DELETE  from SysMenuAuth where MenuId in (SELECT Id FROM SysMenu WHERE AppCode=@AppCode) and AuthorizeId=@authorizeId and AuthorizeType=@authorizeType";
                paramList.Add(new SugarParameter("@AppCode", appCode, System.Data.DbType.String));
            }
            return await db.Ado.ExecuteCommandAsync(strSql, paramList);
        }

        /// <summary>
        /// 获取角色菜单id列表
        /// </summary>
        /// <param name="appCode"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<int>> GetRoleMenuIds(string appCode, int roleId)
        {
            var db = _unitOfWork.GetDbClient();
            var query = await db.Queryable<SysMenu>()
            .InnerJoin<SysMenuAuth>((s, sm) => s.Id == sm.MenuId)
            .Where((s, sm) => s.IsDeleted == 0 && s.AppCode == appCode && sm.AuthorizeId == roleId && sm.AuthorizeType == (int)AuthorizeTypeEnum.Rule)
            .Select((s) => s.Id)
            .ToListAsync();
            return query;

        }
        /// <summary>
        /// 获取角色授权标识列表
        /// </summary>
        /// <param name="appCode"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<string>> GetMenuAuthData(string appCode, int roleId)
        {
            var db = _unitOfWork.GetDbClient();
            var query = await db.Queryable<SysMenu>()
            .InnerJoin<SysMenuAuth>((s, sm) => s.Id == sm.MenuId)
            .Where((s, sm) => s.IsDeleted == 0 && s.AppCode == appCode && sm.AuthorizeId == roleId && sm.AuthorizeType == (int)AuthorizeTypeEnum.Rule)
            .Select((s) => s.Authorize).Distinct()
            .ToListAsync();
            return query;
        }
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="appCode"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<SysMenu>> GetMenuList(string appCode, int roleId)
        {
            var db = _unitOfWork.GetDbClient();
            if (roleId > 1)
            {
                var query = await db.Queryable<SysMenu>()
                .InnerJoin<SysMenuAuth>((s, sm) => s.Id == sm.MenuId)
                .Where((s, sm) => s.MenuType != 3 && s.IsDeleted == 0 && s.AppCode == appCode && sm.AuthorizeId == roleId && sm.AuthorizeType == (int)AuthorizeTypeEnum.Rule)
                .Select((s) => s)
                .ToListAsync();
                return query;
            }
            var list = await db.Queryable<SysMenu>()
                .Where(s => s.MenuType != 3 && s.IsDeleted == 0 && s.AppCode == appCode)
                .ToListAsync();
            return list;
        }
    }
}
