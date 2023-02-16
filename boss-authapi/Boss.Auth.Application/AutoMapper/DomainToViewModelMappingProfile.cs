using AutoMapper;
using Boss.Auth.Model.ViewModels.Req.AppSecret;
using Boss.Auth.Model.ViewModels.Req.Menu;
using Boss.Auth.Model.ViewModels.Req.Position;
using Boss.Auth.Model.ViewModels.Req.Role;
using Boss.Auth.Model.ViewModels.Res.Position;
using Boss.Auth.Model.ViewModels.Res.Role;
using Boss.Auth.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Auth.Model.ViewModels.Res.Menu;
using Boss.Auth.Model.ViewModels.Res.Department;
using Boss.Auth.Model.ViewModels.Req.Department;
using Boss.Auth.Model.ViewModels.Res.User;
using Boss.Auth.Model.ViewModels.Req.User;

namespace Boss.Auth.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AddAppSecretReq, SysAppSecret>();
            CreateMap<AddOrUpdatePositionReq, SysPosition>();
            CreateMap<SysPosition, PositionDto>();
            CreateMap<AddOrUpdateRoleReq, SysRole>();
            CreateMap<SysRole, RoleDto>();
            CreateMap<MenuReq, SysMenu>();
            CreateMap<SysMenu, MenuDto>();
            //部门
            CreateMap<SysDepartment, DepartmentInfoDto>();
            CreateMap<AddOrUpdateDepatmentReq, SysDepartment>();
            //用户
            CreateMap<SysUser, UserDetailDto>();
            CreateMap<AddUserReq, SysUser>();

        }
    }
}
