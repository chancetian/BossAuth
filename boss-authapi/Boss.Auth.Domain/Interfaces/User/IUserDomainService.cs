using Boss.Auth.Model.Entites;
using Boss.Auth.Model.ViewModels.Req.User;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Domain.Interfaces.User
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserDomainService : IBaseDomainService<SysUser>
    {
        /// <summary>
        /// 添加修改用户信息
        /// </summary>
        /// <param name="req">用户信息</param>
        /// <param name="creatorId">操作人ID</param>
        /// <returns></returns>
        Task<string> AddOrUpdateUserInfo(AddUserReq req, int creatorId);
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteUserById(int id);
        /// <summary>
        /// 获取用户分页列表数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<PageDto<UserInfoDto>> PageList(GetUserPageListReq req);
        /// <summary>
        /// 批量添加用户信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<bool> BatchAdd(List<SysUser> list);
    }
}
