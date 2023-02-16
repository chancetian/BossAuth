using AutoMapper;
using Boss.Auth.Application.Interfaces;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Department;
using Boss.Auth.Domain.Interfaces.Department;
using Boss.Auth.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Boss.Auth.Model.ViewModels.Req.Department;
using Boss.Auth.Common.Extensions;
using Boss.Auth.Model.Enum;

namespace Boss.Auth.Application.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        private readonly IDepartmentDomainService _domainService;
        private readonly IMapper _mapper;
        /// <summary>
        /// 部门管理
        /// </summary>
        /// <param name="domainService"></param>
        /// <param name="mapper"></param>
        public DepartmentService(IDepartmentDomainService domainService, IMapper mapper)
        {
            _domainService = domainService;
            _mapper = mapper;   
        }
        /// <summary>
        /// 获取部门数据列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<List<DepartmentDto>>> GetDepartmentList(GetDepartmentListReq req)
        {
            var where = PredicateBuilder.True<SysDepartment>();
            where=where.And(p => p.IsDeleted==0);
            if (!string.IsNullOrEmpty(req.DepartmentName))
            {
                where = where.And(p => p.DepartmentName.Contains(req.DepartmentName));
            }
            if (req.Status>-1)
            {
                where=where.And(p => p.Status==req.Status);
            }

            var list = await _domainService.QueryAsync(where, q => q.CreateTime, SqlSugar.OrderByType.Desc);
            var result = new ResponseDto<List<DepartmentDto>>();
            result.Data = list?.Adapt<List<DepartmentDto>>();
            return result;
        }
        /// <summary>
        /// 获取部门树形结构数据
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<List<DepartmentTreeDto>>> GetDepartmentTreeList()
        {
            var list = await _domainService.QueryAsync(q => q.IsDeleted == 0 && q.Status==1, q => q.Id, SqlSugar.OrderByType.Asc);
            var result = new ResponseDto<List<DepartmentTreeDto>>();
            if (list==null || !list.Any())
            {
                return result;
            }
            result.Data = AddDepartmentChildN(list, 0);
            return result;
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<DepartmentInfoDto>> QueryByID(int id)
        {
            var entity = await _domainService.QueryByID(id);
            if (entity == null)
            {
                return Fail<DepartmentInfoDto>("信息不存在!");
            }
            if (entity.IsDeleted == 1)
            {
                return Fail<DepartmentInfoDto>("信息错误!");
            }
            var model = _mapper.Map<DepartmentInfoDto>(entity);

            return Success(model);
        }
        /// <summary>
        /// 新增部门
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Add(AddOrUpdateDepatmentReq req)
        {
            if (req.ParentId > 0)
            {
                var isExist = await _domainService.IsExistAsync(q => q.Id == req.ParentId);
                if (!isExist)
                {
                    return Fail<string>(" 父部门不存在!");
                }
            }
            var model = _mapper.Map<SysDepartment>(req);
            model.CreateTime = DateTime.Now;
            model.CreatorId = UserId;
            model.Status = (int)DataStatusEnum.Enable;
            var iSave = await _domainService.Add(model);
            return Success();
        }
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<string>> Update(AddOrUpdateDepatmentReq req)
        {
            if (req.ParentId > 0)
            {
                var isExist = await _domainService.IsExistAsync(q => q.Id == req.ParentId);
                if (!isExist)
                {
                    return Fail<string>(" 父部门不存在!");
                }
            }
            var entity = await _domainService.QueryByID(req.Id);
            if (entity == null)
            {
                return Fail("信息不存在!");
            }
            var model = _mapper.Map<SysDepartment>(req);
            model.CreateTime = entity.CreateTime;
            model.CreatorId = entity.CreatorId;
            model.ModifierId = UserId;
            model.ModifyTime = DateTime.Now;
            var result = await _domainService.Update(model);
            return Success();
        }
        /// <summary>
        /// 删除部门信息
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
            var result = await _domainService.DeleteById(id);
            if (result)
            {
                return Success("");
            }
            return Fail("删除失败");
        }
        #region common
        private List<DepartmentTreeDto> AddDepartmentChildN(List<SysDepartment> departList, int pid)
        {
            var data = departList.Where(x => x.ParentId == pid);
            var list = new List<DepartmentTreeDto>();
            foreach (var item in data)
            {
                var childModel = new DepartmentTreeDto();
                childModel.Id = item.Id;
                childModel.Label = item.DepartmentName;
                childModel.Children = GetDepartmentChildList(departList, childModel);
                list.Add(childModel);
            }
            return list;
        }

        private List<DepartmentTreeDto> GetDepartmentChildList(List<SysDepartment> list, DepartmentTreeDto treeChild)
        {
            var flag = list.Where(x => x.ParentId == treeChild.Id).Count() > 0;
            if (!flag)
            {
                return null;
            }
            else
            {
                return AddDepartmentChildN(list, treeChild.Id);
            }
        }
        #endregion

    }
}
