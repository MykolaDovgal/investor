using System.Linq;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> GetPostViewsCountByIdAsync(int postId, bool isUnique)
        {
            IQueryable<string> postsViews = _newsContext.Statistics.Where(s => s.PostId == postId).Select(s => s.ClientIp);

            if (isUnique)
            {
                postsViews = postsViews.Distinct();
            }

            return await postsViews.CountAsync();
        }
    }
}
