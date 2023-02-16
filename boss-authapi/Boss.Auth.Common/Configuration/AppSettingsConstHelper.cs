using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Common.Configuration
{
    public class AppSettingsConstHelper
    {
        #region 数据库================================================================================
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public static readonly string DbSqlConnection = AppSettingsHelper.GetContent<string>("ConnectionStrings", "BossAuthDB");
        /// <summary>
        /// 获取数据库类型
        /// </summary>
        public static readonly string DbDbType = AppSettingsHelper.GetContent<string>("ConnectionStrings", "DbType");
        #endregion

        #region redis缓存================================================================================
        /// <summary>
        /// 是否用redis缓存
        /// </summary>
        public static readonly bool RedisUseCache = AppSettingsHelper.GetContent<bool>("RedisConfig", "RedisUseCache");

        public static readonly string RedisConfigConnectionString = AppSettingsHelper.GetContent<string>("RedisConfig", "ConnectionString");
        #endregion
    }
}
