using AutoMapper;
using Boss.Auth.Application.Helper;
using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Req;
using Boss.Auth.Model.ViewModels.Req.AppSecret;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Domain.Interfaces.AppSecret;
using Boss.Auth.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Auth.Common.Extensions;
using Boss.Auth.Common.Util;
using Mapster;
using Boss.Auth.Model.ViewModels.Res.AppSecret;

namespace Boss.Auth.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class AppSecretService : BaseService,IAppSecretService
    {
        private readonly IAppSecretDomainService _domainService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainService"></param>
        /// <param name="mapper"></param>
        public AppSecretService(IAppSecretDomainService domainService,
            IMapper mapper)
        {
            _domainService = domainService;
        }
        /// <summary>
        /// 添加应用
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> AddAppSecret(AddAppSecretReq req)
        {
            if (string.IsNullOrWhiteSpace(req.AppCode))
            {
                return Fail("AppCode 不能为空");
            }
            if (string.IsNullOrWhiteSpace(req.AppName))
            {
                return Fail("AppName 不能为空");
            }
            req.AppCode = req.AppCode.ToUpper();
            var model = req.Adapt<SysAppSecret>();
            model.AppId = AppUtils.GetAppId();
            model.AppSecret = AppUtils.GetAppSecret(model.AppId);

            var isExist = await _domainService.IsExistAsync(q => q.AppId == model.AppId);
            if (isExist)
            {
                return Fail("AppId 已存在");
            }

            isExist = await _domainService.IsExistAsync(q => q.AppCode == model.AppCode);
            if (isExist)
            {
                return Fail("AppCode 已存在");
            }
            
            model.Status = 1;
            model.CreateTime = DateTime.Now;
            model.CreatorId = jwtUserInfo.Id;
            var result = await _domainService.Add(model);
            if (result)
            {
                return Success("操作成功");
            }
            return Fail("添加应用失败");
        }
        /// <summary>
        /// 获取应用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseDto<AppSecretDto>> GetAppSecret(int id)
        {
            var entity = await _domainService.QueryByID(id);
            if (entity == null)
            {
                return Fail<AppSecretDto>("信息不存在!");
            }
            if (entity.IsDeleted == 1)
            {
                return Fail<AppSecretDto>("信息错误!");
            }
            var model = entity.Adapt<AppSecretDto>();
            return Success<AppSecretDto>(model);
        }
        /// <summary>
        /// 获取应用列表
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<PageDto<AppSecretDto>>> GetPageList(GetAppSecretPageListReq req)
        {
            var pageDto = new PageDto<AppSecretDto>(req.PageNum, req.PageSize);
            var where = PredicateBuilder.True<SysAppSecret>();
            if (!string.IsNullOrEmpty(req.AppName))
            {
                where = where.And(p => p.AppName.Contains(req.AppName));
            }
            if (req.Status > -1)
            {
                where = where.And(p => p.Status == req.Status);
            }
            var result = await _domainService.QueryPageAsync(where, p => p.CreateTime, SqlSugar.OrderByType.Desc, req.PageNum, req.PageSize);
            pageDto.Total = result.TotalCount;
            pageDto.List = result.ToList().Adapt<List<AppSecretDto>>();
            return Success(pageDto);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Delete(int id)
        {
            var entity = await _domainService.QueryByID(id);
            if (entity == null)
            {
                return Fail("信息不存在!");
            }
            if (entity.IsDeleted == 1)
            {
                return Fail("信息错误!");
            }
            entity.IsDeleted = 1;
            entity.ModifierId = UserId;
            entity.ModifyTime = DateTime.Now;
            var result = await _domainService.Update(entity);
            if (result)
                return Success("删除成功");

            return Fail("删除失败");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Update(SysAppSecretReq req)
        {
            var entity = await _domainService.QueryByID(req.Id);
            if (entity == null)
            {
                return Fail("信息不存在!");
            }
            entity.AppName = req.AppName;
            entity.ModifierId = jwtUserInfo.Id;
            entity.ModifyTime = DateTime.Now;
            var result = await _domainService.Update(entity);
            if (result)
                return Success("操作成功");

            return Fail("修改失败");
        }
    }
}
