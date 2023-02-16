using Boss.Auth.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Domain.Interfaces.Role
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRoleDomainService : IBaseDomainService<SysRole>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SysRole> GetRolesByUserID(int userId);
    }
}