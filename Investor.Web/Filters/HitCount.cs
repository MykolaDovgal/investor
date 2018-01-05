using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Investor.Service.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Investor.Web.Filters
{
    internal class HitCount : Attribute, IAsyncActionFilter
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IpService _ipService;

        public HitCount(IStatisticsService statisticsService, IpService ipService)
        {
            _statisticsService = statisticsService;
            _ipService = ipService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {


            await next();

            if (context.ActionArguments.ContainsKey("id"))
            {
                if (context.ActionArguments["id"] is int id)
                {
                    var value = context.HttpContext.Session.GetString(id.ToString());

                    if (value == null)
                    {
                        context.HttpContext.Session.SetString(id.ToString(), "value");
                        await _statisticsService.AddStatistics(new Statistics
                        {
                            PostId = id,
                            Date = DateTime.Now,
                            ClientIp = _ipService.GetRequestIp(),
                        });
                    }
                }
            }
            
        }
    }

}
