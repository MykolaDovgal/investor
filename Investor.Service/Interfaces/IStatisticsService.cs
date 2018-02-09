using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Model;

namespace Investor.Service.Interfaces
{
    public interface IStatisticsService
    {
        Task AddStatisticsAsync(Statistics statistics);
        Task<int> GetPostViewsCountByIdAsync(int postId,bool isUnique = false);
        Task<IEnumerable<int>> GetPopularPostIdsByCategoryAsync(string categoryUrl, int limit, DateTime fromDate,
            DateTime toDate);
    }
}
