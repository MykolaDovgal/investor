using System.Threading.Tasks;
using Investor.Entity;

namespace Investor.Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        Task AddStatistics(StatisticsEntity statistics);
        Task<int> GetPostViewsCountByIdAsync(int postId,bool isUnique);
    }
}
