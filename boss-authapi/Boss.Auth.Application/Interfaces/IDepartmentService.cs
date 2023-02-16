using Boss.Auth.Model.ViewModels.Req.Department;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Interfaces
{
    public interface IDepartmentService
    {
        /// <summary>
        /// 获取部门数据列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<List<DepartmentDto>>> GetDepartmentList(GetDepartmentListReq req);
        /// <summary>
        /// 获取部门树形结构数据
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto<List<DepartmentTreeDto>>> GetDepartmentTreeList();
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDto<DepartmentInfoDto>> QueryByID(int id);
        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> Add(AddOrUpdateDepatmentReq req);
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto<string>> Update(AddOrUpdateDepatmentReq req);
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> Delete(int id);
    }
}
