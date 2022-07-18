using Microsoft.Extensions.Configuration;
using Stable.Business.Abstract.Caching;
using Stable.Business.Concrete.Extensions;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Caching
{
    public class RedisCacheService : ICacheService
    {
        private readonly ConnectionMultiplexer _client;
        private readonly IConfiguration _configuration;

        public RedisCacheService(IConfiguration configuration)
        {
            _configuration = configuration;
          
            var connectionString = _configuration.GetSection("RedisConfiguration:ConnectionString")?.Value;

            ConfigurationOptions options = new ConfigurationOptions
            {
                EndPoints =
                {
                    connectionString 
                },
                AbortOnConnectFail = false,
                AsyncTimeout = 10000,
                ConnectTimeout = 10000
            };

            _client = ConnectionMultiplexer.Connect(options);         
        }

        public void Set(string key, string value)
        {
            var cachettl = int.Parse(_configuration.GetSection("RedisConfiguration:Cachettl").Value);
            _client.GetDatabase().StringSet(key, value,TimeSpan.FromMinutes(cachettl));
        }

        public void Set<T>(string key, T value) where T : class
        {
            var cachettl = int.Parse(_configuration.GetSection("RedisConfiguration:Cachettl").Value);
            _client.GetDatabase().StringSet(key, value.ToJson(), TimeSpan.FromMinutes(cachettl));
        }

        public Task SetAsync(string key, object value)
        {
            var cachettl = int.Parse(_configuration.GetSection("RedisConfiguration:Cachettl").Value);
            return _client.GetDatabase().StringSetAsync(key, value.ToJson(), TimeSpan.FromMinutes(cachettl));
        }

        public void Set(string key, object value, TimeSpan expiration)
        {
            _client.GetDatabase().StringSet(key, value.ToJson(), expiration);
        }

        public Task SetAsync(string key, object value, TimeSpan expiration)
        {
            return _client.GetDatabase().StringSetAsync(key, value.ToJson(), expiration);
        }

        public T Get<T>(string key) where T : class
        {
            string value = _client.GetDatabase().StringGet(key);

            return value.ToObject<T>();
        }

        public string Get(string key)
        {
            return _client.GetDatabase().StringGet(key);
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            string value = await _client.GetDatabase().StringGetAsync(key);

            return value.ToObject<T>();
        }

        public async Task<bool> KeyExistAsync(string key)
        {
            var isExist = await _client.GetDatabase().KeyExistsAsync(key);

            return isExist;
        }
        public void Remove(string key)
        {
            _client.GetDatabase().KeyDelete(key);
        }
    }
}
