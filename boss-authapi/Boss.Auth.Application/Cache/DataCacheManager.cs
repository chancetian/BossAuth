using Boss.Auth.Application.Cache.Interfaces;
using Boss.Auth.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Cache
{
    public static class DataCacheManager
    {
        private static ICacheManager _instance = null;
        /// <summary>
        /// 静态实例，外部可直接调用
        /// </summary>
        public static ICacheManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (AppSettingsConstHelper.RedisUseCache)
                    {
                        _instance = new RedisCacheManager();
                    }
                    else
                    {
                        _instance = new MemoryCacheManager();

                    }
                }
                return _instance;
            }
        }
    }
}
