using Boss.Auth.Application.Cache.Interfaces;
using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Req.User;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.User;
using Boss.Auth.Common.Const;
using Boss.Auth.Common.Util;
using Microsoft.AspNetCore.Mvc;
using Boss.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Boss.Auth.Common.Extensions;

namespace Boss.Auth.WebApi.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="departmentService"></param>
        public UserController(IUserService userService, IDepartmentService departmentService)
        {
            _userService = userService;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(ResponseDto<bool>), 200)]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginReq loginReq)
        {
            var result = await _userService.Login(loginReq);
            return Ok(result);
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Logout")]
        [ProducesResponseType(typeof(ResponseDto<bool>), 200)]
        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            return Ok(new ResponseDto<bool>());
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInfo")]
        [ProducesResponseType(typeof(ResponseDto<GetInfoDto>), 200)]
        public async Task<ActionResult> GetInfo()
        {
            var result = await _userService.GetInfo();
            return Ok(result);
        }
        /// <summary>
        /// 获取用户菜单权限数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRouters")]
        [ProducesResponseType(typeof(ResponseDto<List<GetRoutersDto>>), 200)]
        public async Task<ActionResult> GetRouters()
        {
            var result = await _userService.GetRouters();
            return Ok(result);
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CaptchaImage")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [AllowAnonymous]
        public async Task<ActionResult> CaptchaImage()
        {
            var result = await _userService.CaptchaImage();
            return Ok(result);
        }

        /// <summary>
        /// 获取用户分页列表数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPageList")]
        [ProducesResponseType(typeof(ResponseDto<PageDto<UserInfoDto>>), 200)]
        [PermissionAuthorize("system:user:list")]
        public async Task<ActionResult> PageList([FromBody] GetUserPageListReq req)
        {
            var result = await _userService.PageList(req);
            return Ok(result);
        }
        /// <summary>
        ///获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseDto<UserDetailDto>), 200)]
        [PermissionAuthorize("system:user:view")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _userService.QueryByID(id);
            return Ok(result);
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:user:add")]
        public async Task<ActionResult> Post([FromBody] AddUserReq req)
        {
            var result = await _userService.Add(req);
            return Ok(result);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:user:edit")]
        public async Task<ActionResult> Put([FromBody] AddUserReq req)
        {
            var result = await _userService.Update(req);
            return Ok(result);
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:user:remove")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }
        /// <summary>
        ///启用或禁用用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ChangeStatus")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:user:edit")]
        public async Task<ActionResult> ChangeStatus([FromBody] ChangeUserStatusReq req)
        {
            var result = await _userService.ChangeStatus(req);
            return Ok(result);
        }
        /// <summary>
        ///重置密码
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("ResetPwd")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [PermissionAuthorize("system:user:resetPwd")]
        public async Task<ActionResult> ResetPwd([FromBody]  ResetUserPwdReq req)
        {
            var result = await _userService.ResetPwd(req);
            return Ok(result);
        }
        /// <summary>
        ///导入用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ImportData")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<ActionResult> ImportData(IFormFile file)
        {
            DataTable dt;
            string? msg;
            try
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    dt = ExcelHelper.ExcelToDataTable(ms, Path.GetExtension(file.FileName));
                }
                var list = GetUserByDataTable(dt);
                var result = await _userService.BatchAddUser(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Ok(new ResponseDto<string>
            {
                Code = ResponseCode.Fail,
                Message = msg,
                Data = "",
            });
        }
        private List<AddUserReq> GetUserByDataTable(DataTable dt)
        {
            var list = new List<AddUserReq>();
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new AddUserReq
                {
                    RealName = (string)item["用户姓名"],
                    UserName = (string)item["登录名"],
                    Password = (string)item["用户密码"],
                    Status = ((string)item["状态(1启用,0禁用)"]).ToSafeInt(0),
                    Email = (string)item["邮箱"],
                    Mobile = (string)item["手机号"],
                });
            };
            return list;
        }
    }
}
