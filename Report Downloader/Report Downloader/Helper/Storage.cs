using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Report_Downloader.Helper
{
    public static class Storage
    {
        private static MemoryCache cache = MemoryCache.Default;

        public static void WriteCache(string key, params string[] contents)
        {
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMonths(6);

            foreach (var content in contents)
                cache.Add(key, content, policy);
        }

        public static void WriteCache(string key, params PropertyInfo[] contents)
        {
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMonths(1);

            foreach (var content in contents)
                cache.Add(key, content, policy);
        }

        public static TType GetEntityFromCache<TType>(string key) where TType : class, new()
        {
            if (cache != null && cache.Any())
                return cache.Get(key) as TType;

            return default(TType);
        }
    }
}
