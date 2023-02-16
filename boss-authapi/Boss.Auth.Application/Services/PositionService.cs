using AutoMapper;
using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Req.Position;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Position;
using Boss.Auth.Common.Extensions;
using Boss.Auth.Domain.Interfaces.Position;
using Boss.Auth.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PositionService : BaseService,IPositionService
    {
        private readonly IPositionDomainService _domainService;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainService"></param>
        /// <param name="mapper"></param>
        public PositionService(IPositionDomainService domainService,
            IMapper mapper)
        {
            _domainService = domainService;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Add(AddOrUpdatePositionReq req)
        {
            var model = _mapper.Map<SysPosition>(req);
            model.CreateTime = DateTime.Now;
            model.CreatorId = UserId;
            
            var result = await _domainService.Add(model);
            if (result)
                return Success("");

            return Fail("添加失败");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Update(AddOrUpdatePositionReq req)
        {
            var model = _mapper.Map<SysPosition>(req);
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
                return Success("");

            return Fail("修改失败");
        }

        public async Task<ResponseDto<string>> Delete(int id)
        {
            var entity = await _domainService.QueryByID(id);
            if (entity==null)
            {
                return Fail("信息不存在!");
            }
            var result = await _domainService.DeleteById(id);
            if (result)
                return Success("");

            return Fail("删除失败");
        }

        public async Task<ResponseDto<PositionDto>> QueryByID(int id)
        {
            var entity = await _domainService.QueryByID(id);
            if (entity==null)
            {
                return Fail<PositionDto>("信息不存在!");
            }
            if (entity.IsDeleted==1)
            {
                return Fail<PositionDto>("信息错误!");
            }
            var model = _mapper.Map<PositionDto>(entity);
            return Success<PositionDto>(model);
        }
        public async Task<ResponseDto<int>> GetMaxSort()
        {
            var result =await _domainService.GetMaxSort<SysPosition>();
            return Success(result);
        }

        /// <summary>
        ///  获取职位列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>

        public async Task<ResponseDto<PageDto<PositionDto>>> GetList(PositionListReq req)
        {
            var pageDto=new PageDto<PositionDto>(req.PageNum,req.PageSize);
            var where = PredicateBuilder.True<SysPosition>();
            if (!string.IsNullOrEmpty(req.PositionName))
            {
                where = where.And(p => p.PositionName.Contains(req.PositionName));
            }
            if (req.Status>-1)
            {
                where=where.And(p=>p.Status==req.Status);
            }
            var result =await _domainService.QueryPageAsync(where,p=>p.Sort,SqlSugar.OrderByType.Asc,req.PageNum,req.PageSize);
            pageDto.Total=result.TotalCount;
            pageDto.List=_mapper.Map<List<SysPosition>, List<PositionDto>>(result.ToList());
            return Success<PageDto<PositionDto>>(pageDto);
        }
    }
}