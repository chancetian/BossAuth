using Boss.Auth.Application.Cache.Interfaces;
using Boss.Auth.Common.Configuration;
using Boss.Auth.Common.Extensions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Cache
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly string _redisConnenctionString;

        public volatile ConnectionMultiplexer _instance;

        private readonly object _redisConnectionLock = new object();

        public RedisCacheManager()
        {
            string redisConfiguration = AppSettingsConstHelper.RedisConfigConnectionString;

            if (string.IsNullOrWhiteSpace(redisConfiguration))
            {
                throw new ArgumentException("redis config is empty", nameof(redisConfiguration));
            }
            _redisConnenctionString = redisConfiguration;

            _instance = GetRedisConnection();
        }

        /// <summary>
        /// 获取连接实例
        /// 通过lock的方式，实现单例模式
        /// </summary>
        /// <returns></returns>
        private ConnectionMultiplexer GetRedisConnection()
        {
            //如果已经连接实例，直接返回
            if (_instance != null && _instance.IsConnected)
            {
                return _instance;
            }

            lock (_redisConnectionLock)
            {
                if (_instance != null)
                {
                    //释放redis连接
                    _instance.Dispose();
                }
                try
                {
                    _instance = ConnectionMultiplexer.Connect(_redisConnenctionString);
                }
                catch (Exception)
                {
                    throw new Exception("Redis服务未启用，请开启该服务，并且请注意端口号，Redis默认使用6379端口号。");
                }
            }
            return _instance;
        }


        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return _instance.GetDatabase().KeyExists(key);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool Exists(string key, int db)
        {
            return _instance.GetDatabase(db).KeyExists(key);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresIn">缓存时间</param>
        /// <returns></returns>
        public bool Set(string key, object value, int expiresIn = 0)
        {
            if (value != null)
            {
                //序列化，将object值生成RedisValue
                if (expiresIn > 0)
                {
                    return _instance.GetDatabase().StringSet(key, SerializeExtensions.Serialize(value), TimeSpan.FromMinutes(expiresIn));
                }
                else
                {
                    return _instance.GetDatabase().StringSet(key, SerializeExtensions.Serialize(value));
                }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="db"></param>
        /// <param name="expiresIn"></param>
        /// <returns></returns>
        public bool Set(string key, object value, int db, int expiresIn = 0)
        {
            if (value != null)
            {
                //序列化，将object值生成RedisValue
                if (expiresIn > 0)
                {
                    return _instance.GetDatabase(db).StringSet(key, SerializeExtensions.Serialize(value), TimeSpan.FromMinutes(expiresIn));
                }
                else
                {
                    return _instance.GetDatabase(db).StringSet(key, SerializeExtensions.Serialize(value));
                }
            }
            return false;
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public void Remove(string key)
        {
            _instance.GetDatabase().KeyDelete(key);
        }

        public bool LockTake(string key, string value, TimeSpan timeSpan)
        {
            return _instance.GetDatabase().LockTake(key, value, timeSpan);
        }

        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <returns></returns>
        public void RemoveAll(IEnumerable<string> keys)
        {
            foreach (var key in keys)
            {
                _instance.GetDatabase().KeyDelete(key);
            }

        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            var value = _instance.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                //需要用的反序列化，将Redis存储的Byte[]，进行反序列化
                return SerializeExtensions.Deserialize<T>(value);
            }

            return default;
        }
        public T Get<T>(string key, int db)
        {
            var value = _instance.GetDatabase(db).StringGet(key);
            if (value.HasValue)
            {
                //需要用的反序列化，将Redis存储的Byte[]，进行反序列化
                return SerializeExtensions.Deserialize<T>(value);
            }

            return default;
        }
        public object Get(string key)
        {
            return _instance.GetDatabase().StringGet(key);
        }
        public object Get(string key, int db)
        {
            return _instance.GetDatabase(db).StringGet(key);
        }

        public IDictionary<string, object> GetAll(IEnumerable<string> keys)
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));
            var dict = new Dictionary<string, object>();

            keys.ToList().ForEach(item => dict.Add(item, _instance.GetDatabase().StringGet(item)));
            return dict;

        }

        public void RemoveCacheAll()
        {
            foreach (var endPoint in GetRedisConnection().GetEndPoints())
            {
                var server = GetRedisConnection().GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    _instance.GetDatabase().KeyDelete(key);
                }
            }
        }

        public void RemoveCacheRegex(string pattern)
        {
            var script = "return redis.call('keys',@pattern)";
            var prepared = LuaScript.Prepare(script);
            var redisResult = _instance.GetDatabase().ScriptEvaluate(prepared, new { pattern });
            if (!redisResult.IsNull)
            {
                _instance.GetDatabase().KeyDelete((RedisKey[])redisResult); //删除一组key
            }
        }

        public IList<string> SearchCacheRegex(string pattern)
        {
            var list = new List<String>();
            var script = "return redis.call('keys',@pattern)";
            var prepared = LuaScript.Prepare(script);
            var redisResult = _instance.GetDatabase().ScriptEvaluate(prepared, new { pattern });
            if (!redisResult.IsNull)
            {
                foreach (var key in (RedisKey[])redisResult)
                {
                    list.Add(_instance.GetDatabase().StringGet(key));
                }
            }
            return list;
        }
    }
}
