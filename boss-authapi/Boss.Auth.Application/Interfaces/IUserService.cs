using Boss.Auth.Model.ViewModels.Req.User;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginReq"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> Login(LoginReq loginReq);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto<GetInfoDto>> GetInfo();
        /// <summary>
        /// 获取当前用户权限菜单
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto<List<GetRoutersDto>>> GetRouters();
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto<CaptchaImageDto>> CaptchaImage();
        /// <summary>
        /// 获取用户分页列表数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<PageDto<UserInfoDto>>> PageList(GetUserPageListReq req);

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDto<UserDetailDto>> QueryByID(int id);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> Add(AddUserReq req);
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> Update(AddUserReq req);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> Delete(int id);
        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> ChangeStatus(ChangeUserStatusReq req);
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> ResetPwd(ResetUserPwdReq req);
        /// <summary>
        /// 批量添加用户
        /// </summary>
        /// <returns></returns>
         Task<ResponseDto<string>> BatchAddUser(List<AddUserReq> req);
    }
}
