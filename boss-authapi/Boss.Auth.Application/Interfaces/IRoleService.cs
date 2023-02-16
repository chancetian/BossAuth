using Boss.Auth.Model.ViewModels.Req.Role;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Interfaces
{
    public interface IRoleService
    {
        Task<ResponseDto<string>> Add(AddOrUpdateRoleReq req);

        Task<ResponseDto<string>> Update(AddOrUpdateRoleReq req);

        Task<ResponseDto<string>> Delete(int id);

        Task<ResponseDto<RoleDto>> QueryByID(int id);

        Task<ResponseDto<PageDto<RoleDto>>> GetPageList(GetRolePageListReq req);
    }
}