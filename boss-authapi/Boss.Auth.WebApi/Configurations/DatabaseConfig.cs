using Boss.Auth.Common.Configuration;
using Boss.Auth.Common.Log;
using SqlSugar;
using SqlSugar.IOC;

namespace Boss.Auth.WebApi.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            //注入 ORM
            SugarIocServices.AddSqlSugar(new IocConfig()
            {
                //数据库连接
                ConnectionString = AppSettingsConstHelper.DbSqlConnection,
                //判断数据库类型
                DbType = AppSettingsConstHelper.DbDbType == IocDbType.MySql.ToString() ? IocDbType.MySql : IocDbType.SqlServer,
                //是否开启自动关闭数据库连接-//不设成true要手动close
                IsAutoCloseConnection = true,
            });

            //设置参数
            services.ConfigurationSugar(db =>
            {
                db.CurrentConnectionConfig.InitKeyType = InitKeyType.Attribute;
                //db.CurrentConnectionConfig.ConfigureExternalServices = new ConfigureExternalServices()
                //{
                //    //判断是否开启redis设置二级缓存方式
                //    DataInfoCacheService = AppSettingsHelper.RedisUseCache ? (ICacheService)new SqlSugarRedisCache() : new SqlSugarMemoryCache()
                //};

                //执行SQL，可监控sql
                db.Aop.OnLogExecuting = (sql, p) =>
                {
                    LoggerHelper.Info($"SqlSugar执行SQL:{sql}");
                };

                //执行SQL 错误事件
                db.Aop.OnError = (exp) =>
                {
                    LoggerHelper.Error(exp, "SqlSugar执行SQL错误事件");
                };
            });
        }
    }
}
