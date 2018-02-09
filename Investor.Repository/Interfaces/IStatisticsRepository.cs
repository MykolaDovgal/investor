using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Entity;

namespace Investor.Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        Task AddStatistics(StatisticsEntity statistics);
        Task<int> GetPostViewsCountByIdAsync(int postId,bool isUnique);
        Task<IEnumerable<int>> GetPopularPostIdsByCategoryAsync(string categoryUrl, int limit, DateTime fromDate,
            DateTime toDate);
    }
}
