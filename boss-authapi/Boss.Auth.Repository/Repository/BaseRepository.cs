using Boss.Auth.Model;
using Boss.Auth.Repository.Interfaces;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly SqlSugarScope _sqlSugarScope;

        protected BaseRepository(IUnitOfWork unitOfWork)
        {
            _sqlSugarScope = unitOfWork.GetDbClient();
        }
        protected ISqlSugarClient DBClient => _sqlSugarScope;

        public async Task<bool> Add(T model)
        {
            return await DBClient.Insertable(model).ExecuteCommandIdentityIntoEntityAsync();
        }
        public async Task<bool> BulkInsert(List<T> list)
        {
            return await DBClient.Insertable<T>(list).ExecuteCommandAsync()>0?true:false;
        }
        public async Task<int> AddReturnId(T model)
        {
            return await DBClient.Insertable(model).ExecuteReturnIdentityAsync();
        }
        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await DBClient.Deleteable<T>().In(ids).ExecuteCommandHasChangeAsync();
        }
        public async Task<bool> DeleteById(int id)
        {
            return await DBClient.Deleteable<T>(id).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> where)
        {
            return await DBClient.Deleteable(where).ExecuteCommandHasChangeAsync();
        }

        public async Task<T> QueryByID(object objId)
        {
            return await DBClient.Queryable<T>().InSingleAsync(objId);
        }

        public async Task<bool> Update(T model)
        {
            return await DBClient.Updateable(model).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> UpdateAsync(T model, string strWhere)
        {
            return await DBClient.Updateable(model).Where(strWhere).ExecuteCommandHasChangeAsync();
        }
        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> where)
        {
            return await DBClient.Queryable<T>().AnyAsync(where);
        }
        public async Task<IPageList<T>> QueryPageAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByExpression, OrderByType orderByType, int pageIndex = 1, int pageSize = 10)
        {
            RefAsync<int> totalCount = 0;
            var data = await DBClient.Queryable<T>().WhereIF(predicate != null, predicate).OrderByIF(orderByExpression != null, orderByExpression, orderByType).ToPageListAsync(pageIndex, pageSize, totalCount);
            var list = new PageList<T>(data, pageIndex, pageSize, totalCount);
            return list;
        }

        public async Task<IPageList<dynamic>> QueryPageAsync(string sql,string whereSql, object parameters,string orderBy,int pageNum = 1, int pageSize = 10)
        {
            RefAsync<int> totalCount = 0;
            var data = await DBClient.SqlQueryable<dynamic>(sql).Where(whereSql, parameters).OrderBy(orderBy).ToPageListAsync(pageNum, pageSize, totalCount);
            var list = new PageList<dynamic>(data, pageNum, pageSize, totalCount);
            return list;
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByExpression, OrderByType orderByType)
        {
            return await DBClient.Queryable<T>().WhereIF(predicate != null, predicate).OrderByIF(orderByExpression != null, orderByExpression, orderByType).ToListAsync();
        }
        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await DBClient.Queryable<T>().Where(predicate).FirstAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sort"></param>
        /// <returns></returns>
        public async Task<int> GetMaxSort<T>(string sort= "Sort")
        {
            string res = typeof(T).ToString();
            int start = res.LastIndexOf('.') + 1;

            var tableName = res.Substring(start, res.Length - start);
            var sql = $"SELECT IFNULL(MAX({sort}),0)+1 AS Sort FROM {tableName}";
            var obj = await DBClient.Ado.GetScalarAsync(sql);
            return Convert.ToInt32(obj);
        }
    }
}
