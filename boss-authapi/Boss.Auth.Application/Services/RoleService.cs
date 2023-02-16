using AutoMapper;
using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Req.Role;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Role;
using Boss.Auth.Common.Extensions;
using Boss.Auth.Domain.Interfaces.Role;
using Boss.Auth.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Auth.Domain.Interfaces.Menu;
using SqlSugar;
using Boss.Auth.Model.Enum;

namespace Boss.Auth.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleService : BaseService,IRoleService
    {
        private readonly IRoleDomainService _domainService;
        private readonly IMenuDomainService  _menuDomainService;
        private readonly IMenuAuthDomainService _menuAuthDomainService;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainService"></param>
        /// <param name="menuDomainService"></param>
        /// <param name="menuAuthDomainService"></param>
        /// <param name="mapper"></param>
        public RoleService(IRoleDomainService domainService,
            IMenuDomainService   menuDomainService,
            IMenuAuthDomainService menuAuthDomainService,
            IMapper mapper)
        {
            _domainService = domainService;
            _menuAuthDomainService = menuAuthDomainService;
            _menuDomainService = menuDomainService;
            _mapper = mapper;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Add(AddOrUpdateRoleReq req)
        {
            var model = _mapper.Map<SysRole>(req);
            model.CreateTime = DateTime.Now;
            model.CreatorId = UserId;
            if (req.MenuIds != null && req.MenuIds.Count > 0)
            {
                foreach (var item in req.MenuIds)
                {
                  var isExist= await _menuDomainService.IsExistAsync(q => q.Id == item);
                    if (!isExist)
                    {
                        return Fail($"添加失败  MenuIds:{item}");
                    }
                }
            }
            var id = await _domainService.AddReturnId(model);
            if (id>0)
            {
                if (req.MenuIds != null && req.MenuIds.Count > 0)
                {
                    foreach (var item in req.MenuIds)
                    {
                        await _menuAuthDomainService.Add(new SysMenuAuth
                        {
                            AuthorizeId = id,
                            AuthorizeType = 1,
                            CreateTime = DateTime.Now,
                            CreatorId = UserId,
                            MenuId = item
                        });
                    }
                }
                return Success("");
            }

            return Fail("添加失败");
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Update(AddOrUpdateRoleReq req)
        {
            var model = _mapper.Map<SysRole>(req);
            var entity=await _domainService.QueryByID(req.Id);
            model.CreateTime = entity.CreateTime;
            model.CreatorId = entity.CreatorId;
            if (entity==null)
            {
                return Fail("信息不存在!");
            }
            model.ModifierId=UserId;
            model.ModifyTime=DateTime.Now;
            var result = await _domainService.Update(model);
            if (result)
            {
                await _menuAuthDomainService.DeletMenuAuth(entity.Id, (int)AuthorizeTypeEnum.Rule,req.AppCode);

                if (req.MenuIds != null && req.MenuIds.Count > 0)
                {
                    foreach (var item in req.MenuIds)
                    {
                        await _menuAuthDomainService.Add(new SysMenuAuth
                        {
                            AuthorizeId = entity.Id,
                            AuthorizeType = (int)AuthorizeTypeEnum.Rule,
                            CreateTime = DateTime.Now,
                            CreatorId = UserId,
                            MenuId = item
                        });
                    }
                }
             
                return Success("");
            }
               

            return Fail("修改失败");
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Delete(int id)
        {
            var entity = await _domainService.QueryByID(id);
            if (entity==null)
            {
                return Fail("信息不存在!");
            }
            var result = await _domainService.DeleteById(id);
            if (result)
            {
                await _menuAuthDomainService.DeletMenuAuth(entity.Id, (int)AuthorizeTypeEnum.Rule);
                return Success("");

            }

            return Fail("删除失败");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         public async Task<ResponseDto<RoleDto>> QueryByID(int id)
        {
            var entity = await _domainService.QueryByID(id);
            if (entity==null)
            {
                return Fail<RoleDto>("信息不存在!");
            }
            if (entity.IsDeleted==1)
            {
                return Fail<RoleDto>("信息错误!");
            }
            var model = _mapper.Map<RoleDto>(entity);
          
            return Success<RoleDto>(model);
        }
        /// <summary>
        /// 获取角色分页数据列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<PageDto<RoleDto>>> GetPageList(GetRolePageListReq req)
        {
            var pageDto = new PageDto<RoleDto>(req.PageNum, req.PageSize);
            var where = PredicateBuilder.True<SysRole>();
            if (!string.IsNullOrEmpty(req.RoleName))
            {
                where = where.And(p => p.RoleName.Contains(req.RoleName));
            }
            if (req.Status > -1)
            {
                where = where.And(p => p.Status == req.Status);
            }
            if (!string.IsNullOrEmpty(req.Params.BeginTime) && !string.IsNullOrEmpty(req.Params.EndTime))
            {
                var beginTime = Convert.ToDateTime(req.Params.BeginTime);
                var endTime = Convert.ToDateTime(req.Params.EndTime).AddDays(1);
                where = where.And(p => p.CreateTime>=beginTime && p.CreateTime<endTime);
            }
            var result = await _domainService.QueryPageAsync(where, p => p.Sort, SqlSugar.OrderByType.Asc, req.PageNum, req.PageSize);
            pageDto.Total=result.TotalCount;
            pageDto.List=_mapper.Map<List<SysRole>, List<RoleDto>>(result.ToList());
            return Success<PageDto<RoleDto>>(pageDto);
        }
    }
}