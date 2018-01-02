using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Investor.Service.Utils
{
    public class CurrencyService
    {
        private readonly IMemoryCache _memoryCache;

        public CurrencyService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public double GetRate(string currencyAbbreviation)
        {
            if (_memoryCache.TryGetValue(currencyAbbreviation, out double rate))
            {
                return Math.Round(rate, 2);
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    string response = client
                        .GetStringAsync($"http://localhost:50583/api/currency?currencyAbbreviation={currencyAbbreviation}").Result;
                    rate = double.Parse(response, CultureInfo.InvariantCulture);
                }
                _memoryCache.Set(currencyAbbreviation, rate,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                return Math.Round(rate, 2);
            }
        }
    }
}
