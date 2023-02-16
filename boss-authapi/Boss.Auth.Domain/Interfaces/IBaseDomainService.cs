using Boss.Auth.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Domain.Interfaces
{
    public interface IBaseDomainService<T> where T : class
    {
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        Task<T> QueryByID(object objId);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Add(T model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddReturnId(T model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Update(T model);
        /// <summary>
        /// 根据手写条件更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T model, string strWhere);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteByIds(object[] ids);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteById(int id);
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<bool> IsExistAsync(Expression<Func<T, bool>> where);
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="orderByType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IPageList<T>> QueryPageAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByExpression, OrderByType orderByType, int pageIndex = 1, int pageSize = 10);
        /// <summary>
        /// SQL分页
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="whereSql"></param>
        /// <param name="parameters"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IPageList<dynamic>> QueryPageAsync(string sql, string whereSql, object parameters, string orderBy, int pageIndex = 1, int pageSize = 10);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="orderByType"></param>
        /// <returns></returns>
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByExpression, OrderByType orderByType);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> GetMaxSort<T>();
    }
}
