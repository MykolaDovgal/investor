using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace Investor.Service.Utils
{
    public class CurrencyService
    {
        private readonly HttpClient _httpClient;
        private readonly CacheService _cacheService;
        private const string UrlPattern = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
        public CurrencyService(CacheService cacheService)
        {
            _httpClient = new HttpClient();
            _cacheService = cacheService;
        }

        public Dictionary<string, double> GetRate(IEnumerable<string> keysList)
        {  
            Dictionary<string, double> rates = (Dictionary<string, double>)_cacheService.GetValue("Currency");

            if (rates != null) return rates;

            rates = GetRatesDictionary(keysList).Result;
            _cacheService.SetValue("Currency", rates, TimeSpan.FromMinutes(30));

            return rates;
        }

        private async Task<Dictionary<string, double>> GetRatesDictionary(IEnumerable<string> keys)
        {
            var response = await _httpClient.GetStringAsync(UrlPattern);

            JArray jObject = JArray.Parse(response);
            Dictionary<string, double> rates = new Dictionary<string, double>();

            foreach (var k in keys)
            {
                JToken rate = jObject.FirstOrDefault(c => c["cc"].ToString() == k);
                if (rate != null)
                {
                    rates.Add(k, Math.Round(double.Parse(rate["rate"].ToString()), 2));
                }             
            }

            return rates;
        }
    }
}
