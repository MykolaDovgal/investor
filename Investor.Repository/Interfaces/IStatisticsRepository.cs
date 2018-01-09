using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Model;

namespace Investor.Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        Task AddStatistics(StatisticsEntity statistics);
        Task<int> GetPostViewsCountByIdAsync(int postId,bool isUnique);
    }
}
