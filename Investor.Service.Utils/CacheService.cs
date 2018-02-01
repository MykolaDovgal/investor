using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace Investor.Service.Utils
{
    public class CacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public object GetValue(string key)
        {
            _memoryCache.TryGetValue(key, out object value);
            return value;
        }

        public Dictionary<string, object> GetValue(List<string> key)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            key?.ForEach(k =>
            {
                _memoryCache.TryGetValue(k, out object value);
                dictionary.Add(k, value);

            });
            return dictionary;
        }

        public void SetValue(Dictionary<string, object> setDictionary, TimeSpan timeTerm)
        {
            foreach (var keyValuePair in setDictionary)
            {
                _memoryCache.Set(keyValuePair.Key, keyValuePair.Key, timeTerm);
            }
        }

        public void SetValue(string key, object value, TimeSpan timeTerm)
        {
            _memoryCache.Set(key, value, timeTerm);
        }
    }
}
