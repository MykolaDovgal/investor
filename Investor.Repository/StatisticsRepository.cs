using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Model;
using Investor.Repository.Interfaces;

namespace Investor.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {

        private readonly NewsContext _newsContext;
        public StatisticsRepository(NewsContext context)
        {
            _newsContext = context;
        }
        public async Task AddStatistics(StatisticsEntity statistics)
        {
            _newsContext.Statistics.Add(statistics);
            await _newsContext.SaveChangesAsync();
        }
    }
}
