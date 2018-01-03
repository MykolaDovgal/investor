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
        private HttpClient _httpClient;
        private Dictionary<string, double> _currencyRates;
        private CacheService _cacheService;
        public CurrencyService(CacheService cacheService)
        {
            _httpClient = new HttpClient();
            _currencyRates = new Dictionary<string, double>();
            _cacheService = cacheService;
        }
        public Dictionary<string, double> GetRate(List<string> keysList)
        {
            Dictionary<string, double> rates = (Dictionary<string, double>)_cacheService.GetValue("Currency");
            if (! keysList.Any(c => { return rates != null && rates.ContainsKey(c); }))
            {
                rates = GetRatesDictionary(keysList).Result;
                _cacheService.SetValue("Currency", (object) rates, TimeSpan.FromMinutes(5));
            }
            return rates;
        }

        private async Task<Dictionary<string, double>> GetRatesDictionary(List<string> keys)
        {
            const string urlPattern = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
            string response = await _httpClient.GetStringAsync(urlPattern);
            JArray jObject = JArray.Parse(response);
            Dictionary<string, double> rates = new Dictionary<string, double>();
            keys.ForEach(k =>
            {
                JToken rate = jObject.First(c => (string)c["cc"] == k);
                rates.Add(k, Math.Round(double.Parse((string)rate["rate"], CultureInfo.InvariantCulture), 2)); ;
            });
            return rates;
        }
    }
}
