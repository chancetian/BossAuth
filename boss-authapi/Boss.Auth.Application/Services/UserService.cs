using Boss.Auth.Application.Cache.Interfaces;
using Boss.Auth.Application.Helper;
using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Req.User;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.User;
using Boss.Auth.Common.Const;
using Boss.Auth.Common.Util;
using Boss.Auth.Domain.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Auth.Application.Cache;
using Boss.Auth.Domain.Interfaces.Role;
using AutoMapper;
using Boss.Auth.Domain.Interfaces.Department;
using Boss.Auth.Model.ViewModels.Res.Department;
using Boss.Auth.Model.ViewModels.Res.Role;
using Boss.Auth.Model.Entites;
using Boss.Auth.Domain.Interfaces.Position;
using Boss.Auth.Domain.Interfaces.Menu;
using Newtonsoft.Json.Linq;
using Boss.Auth.Common.Configuration;
using Boss.Auth.Domain.Interfaces.AppSecret;
using Mapster;

namespace Boss.Auth.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly ICacheManager _cacheManager;
        private readonly IUserDomainService _userDomainService;
        private readonly IDepartmentDomainService  _departmentDomainService;
        private readonly IRoleDomainService  _roleDomainService;
        private readonly IPositionDomainService  _positionDomainService;
        private readonly IMapper _mapper;
        private readonly IMenuAuthDomainService _menuAuthDomainService;
        private readonly IAppSecretDomainService _appSecretDomainService;
        private readonly JwtHelper _jwtHelper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDomainService"></param>
        /// <param name="departmentDomainService"></param>
        /// <param name="roleDomainService"></param>
        /// <param name="positionDomainService"></param>
        /// <param name="menuAuthDomainService"></param>
        /// <param name="appSecretDomainService"></param>
        /// <param name="jwtHelper"></param>
        /// <param name="mapper"></param>
        public UserService(IUserDomainService userDomainService,
            IDepartmentDomainService departmentDomainService,
            IRoleDomainService roleDomainService,
            IPositionDomainService positionDomainService,
            IMenuAuthDomainService menuAuthDomainService,
            IAppSecretDomainService appSecretDomainService,
            JwtHelper jwtHelper,
            IMapper mapper)
        {
            _cacheManager=DataCacheManager.Instance;
            _userDomainService=userDomainService;
            _departmentDomainService = departmentDomainService;
            _roleDomainService = roleDomainService;
            _positionDomainService = positionDomainService;
            _menuAuthDomainService=menuAuthDomainService;
            _appSecretDomainService = appSecretDomainService;
            _jwtHelper =jwtHelper;
            _mapper = mapper;
        }
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<GetInfoDto>> GetInfo()
        {
            var userInfoModel = await _userDomainService.QueryByID(UserId);
            var roles=new List<string>();
            if (userInfoModel.IsAdmin==1)
            {
                roles.Add("admin");
            }
            else
            {
                roles.Add("noadmin");
            }
            var dto = new GetInfoDto
            {
                Permissions = new List<string>
                {
                    "*:*:*"
                },
                Roles = roles,
                User=new UserInfoDto
                {
                    Id= userInfoModel.Id,
                    UserName= userInfoModel.UserName,
                    DepartmentId= userInfoModel.DepartmentId,
                    Email= userInfoModel.Email
                }
            };
            return Success(dto);
        }
        /// <summary>
        /// 获取当前用户权限菜单
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<List<GetRoutersDto>>> GetRouters()
        {
            var list = await _menuAuthDomainService.GetMenuList(jwtUserInfo.AppCode, jwtUserInfo.RoleId);
            var result = new ResponseDto<List<GetRoutersDto>>();
            if (list == null || !list.Any())
            {
                return result;
            }
            result.Data = AddTreeChildN(list, 0);
            return result;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginReq"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Login(LoginReq loginReq)
        {
            var imgCode = _cacheManager.Get($"{loginReq.Uuid}_{SystemConst.CaptchaCode}");
            if (imgCode == null || loginReq.Code!=imgCode?.ToString())
            {
                return Fail<string>("验证码错误，请重新输入");
            }

            var userModel =  await _userDomainService.FindSingleAsync(p => p.UserName==loginReq.UserName);
            if (userModel == null)
            {
                return Fail<string>("账号不存在，请重新输入");
            }
             
            var pwd =SecurityHelper.EncryptUserPassword(loginReq.Password, userModel.Salt);
            if (!userModel.Password.Equals(pwd))
            {
                return Fail<string>("密码不正确，请重新输入");
            }
            var roleModel=await _roleDomainService.GetRolesByUserID(userModel.Id);
            var authData = "";
            var appCode = AppSettingsHelper.GetContent<string>("AppConfig", "AppCode");
            var isExit=await _appSecretDomainService.IsExistAsync(p=>p.AppCode==appCode);
            if (!isExit)
            {
                return Fail<string>("应用配置错误");
            }
            if (roleModel!=null && roleModel.Id != 1)
            {
                var list = await _menuAuthDomainService.GetMenuAuthData(appCode,roleModel.Id);
                if(list!=null && list.Any())
                {
                    authData=String.Join(",", list);
                }
            }
            var token = _jwtHelper.CreateToken(new JwtUserInfo
            {
                UserName=userModel.UserName,
                Id=userModel.Id,
                RoleId = roleModel.Id,
                RoleName = roleModel.RoleName,
                AppCode = appCode,
                Data= authData
            });
            return Success(token);
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<CaptchaImageDto>> CaptchaImage()
        {
            Tuple<string, int> captchaCode = CaptchaHelper.GetCaptchaCode();
            byte[] bytes = CaptchaHelper.CreateCaptchaImage(captchaCode.Item1);
            var uuid = StringHelper.GetUUID();
            string data = Convert.ToBase64String(bytes);
            var dto = new CaptchaImageDto
            {
                Uuid=uuid,
                ImgData=data
            };
            _cacheManager.Set($"{uuid}_{SystemConst.CaptchaCode}", captchaCode.Item2, 5);
            return Success(dto);
        }

        /// <summary>
        /// 获取用户分页列表数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<PageDto<UserInfoDto>>> PageList(GetUserPageListReq req)
        {
            var result=await _userDomainService.PageList(req);
            return Success<PageDto<UserInfoDto>>(result);
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseDto<UserDetailDto>> QueryByID(int id)
        {
            var entity = await _userDomainService.QueryByID(id);
            if (entity == null)
            {
                return Fail<UserDetailDto>("信息不存在!");
            }
            if (entity.IsDeleted == 1)
            {
                return Fail<UserDetailDto>("信息错误!");
            }
            var model = _mapper.Map<UserDetailDto>(entity);
          
            if (entity.DepartmentId != null)
            {
                var deptModel = await _departmentDomainService.QueryByID(entity.DepartmentId);
                if (deptModel != null)
                {
                    var dept = _mapper.Map<DepartmentInfoDto>(deptModel);
                    model.Dept = dept;
                }
            }
            var roleModel = await _roleDomainService.GetRolesByUserID(entity.Id);
            if (roleModel != null)
            {
                model.RoleIds = roleModel.Id;
            }
            model.PostIds = entity.PositionId;
            return Success(model);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Add(AddUserReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Password))
            {
                return Fail("密码不能为空!");
            }
            if (req.DepartmentId > 0)
            {
                var isExist= await _departmentDomainService.IsExistAsync(q=>q.Id==req.DepartmentId);
                if (!isExist)
                {
                    return Fail("部门选择错误!");
                }
            }
            var result = await _userDomainService.AddOrUpdateUserInfo(req, UserId);
            if (string.IsNullOrEmpty(result))
            {
                return Success("");
            }
            return Fail(result);
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Update(AddUserReq req)
        {
            var entity = await _userDomainService.QueryByID(req.Id);
            if (entity == null)
            {
                return Fail("未找到用戶!");
            }

            var result = await _userDomainService.AddOrUpdateUserInfo(req,UserId);
            if (string.IsNullOrEmpty(result))
            {
                return Success("");
            }
            return Fail(result);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Delete(int id)
        {
            var entity = await _userDomainService.QueryByID(id);
            if (entity == null)
            {
                return Fail("信息不存在!");
            }
            var result = await _userDomainService.DeleteUserById(id);
            if (string.IsNullOrEmpty(result))
            {
                return Success("");
            }
            return Fail(result);
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> ChangeStatus(ChangeUserStatusReq req)
        {
            var entity = await _userDomainService.QueryByID(req.UserId);
            if (entity == null)
            {
                return Fail("信息不存在!");
            }
            entity.Status = req.Status;
            var result = await _userDomainService.Update(entity);
            if (result)
            {
                return Success("");
            }
            return Fail("删除失败");
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> ResetPwd(ResetUserPwdReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Password))
            {
                return Fail("密码不能为空!");
            }
            var entity = await _userDomainService.QueryByID(req.UserId);
            if (entity == null)
            {
                return Fail("信息不存在!");
            }
            var salt = StringHelper.GetUUID();
            entity.Salt = salt;
            entity.Password = SecurityHelper.EncryptUserPassword(req.Password, salt);
            var result = await _userDomainService.Update(entity);
            if (result)
            {
                return Success("");
            }
            return Fail("删除失败");
        }

        /// <summary>
        /// 批量添加用户
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<string>> BatchAddUser(List<AddUserReq> req)
        {
            var list = req.Adapt<List<SysUser>>();

            foreach (var item in list)
            {
                var salt = StringHelper.GetUUID();
                item.Password = SecurityHelper.EncryptUserPassword(item.Password, salt);
                item.Salt = salt;
                item.PositionId = 0;
                item.Status = item.Status == 1 ? item.Status : 0;
                item.CreatorId = UserId;
                item.CreateTime = DateTime.Now;
            }
            var isSave = await _userDomainService.BatchAdd(list);
            if (isSave)
            {
                return Success("");
            }
            return Fail("提交失败");
        }

        #region 内部方法
        private List<GetRoutersDto> AddTreeChildN(List<SysMenu> menuList, int pid)
        {
            var data = menuList.Where(x => x.ParentId == pid);
            var list = new List<GetRoutersDto>();
            foreach (var item in data)
            {
                var childModel = new GetRoutersDto();
                childModel.Id = item.Id;
                childModel.Name = item.Path;
                childModel.Path = item.ParentId == 0 ? $"/{item.Path}": item.Path;
                if (item.ParentId == 0)
                {
                    childModel.Redirect = "noRedirect";
                    childModel.AlwaysShow = true;
                }
                else
                {
                    childModel.Redirect = null;
                }
                childModel.Component =item.ParentId==0? "Layout" : item.MenuUrl;
                childModel.Meta = new MetaModel
                {
                    Title=item.MenuName,
                    Icon=item.MenuIcon,
                };
                childModel.Children = GetTreeChildList(menuList, childModel);
                list.Add(childModel);
            }
            return list;
        }
        private List<GetRoutersDto> GetTreeChildList(List<SysMenu> list, GetRoutersDto treeChild)
        {
            var flag = list.Where(x => x.ParentId == treeChild.Id).Count() > 0;
            if (!flag)
            {
                return null;
            }
            else
            {
                return AddTreeChildN(list, treeChild.Id);
            }
        }
        #endregion
    }
}
