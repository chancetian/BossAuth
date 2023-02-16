
using Boss.Auth.Domain.Interfaces.Role;
using Boss.Auth.Model.Entites;
using Boss.Auth.Repository.Interfaces;
using Boss.Auth.Repository.Interfaces.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Domain.Services.Role
{
    public class RoleDomainService : BaseDomainService<SysRole>, IRoleDomainService
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleDomainService(IUnitOfWork unitOfWork,
            IRoleRepository repository)
        {
            this._repository = repository;
            base._baseRepository = repository;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        ///根据用户id获取角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<SysRole> GetRolesByUserID(int userId)
        {
            var db = _unitOfWork.GetDbClient();
            var model = await db.Queryable<SysRole>()
            .InnerJoin<SysUserRole>((s, sm) => s.Id == sm.RoleId)
            .Where((s, sm) => s.IsDeleted == 0 && sm.UserId == userId)
            .Select(s => s)
            .FirstAsync();
            return model;
        }
    }
}
