using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Investor.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class Currency : Controller
    {
        public static double GetRate(string currencyAbbreviation)
        {
            HttpClient web = new HttpClient();
            const string urlPattern = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
            string response = web.GetStringAsync(urlPattern).Result;
            JArray jObject = JArray.Parse(response);
            JToken rate = jObject.First(c => (string)c["cc"] == currencyAbbreviation);
            var vr = (string)rate["rate"];
            return double.Parse((string)rate["rate"], CultureInfo.InvariantCulture);
        }
    }
}
