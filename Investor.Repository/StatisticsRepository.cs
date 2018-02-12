using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<int>> GetPopularPostIdsByCategoryAsync(string categoryUrl, int limit, DateTime fromDate, DateTime toDate)
        {
            IQueryable<int> postIdsByCategoryUrl = _newsContext.Posts
                .Include(x => x.Category)
                .Where(x => x.Category.Url == categoryUrl)
                .Select(x => x.PostId);

            return await _newsContext.Statistics
                .Where(record => record.Date >= fromDate && record.Date <= toDate)
                .Where(x => postIdsByCategoryUrl.Contains(x.PostId))
                .GroupBy(record => new { record.PostId, record.ClientIp })
                .Select(allHit => new { Name = allHit.Key, Count = allHit.Count() })
                .OrderByDescending(uniqueHit => uniqueHit.Count)
                .Select(uniqueHit => uniqueHit.Name.PostId)
                .Take(limit)
                .ToListAsync();

            //return await (from record in _newsContext.Statistics
            //              where record.Date >= fromDate && record.Date <= toDate
            //              group record by new { record.PostId, record.ClientIp } into allHit
            //              select new
            //              {
            //                  Name = allHit.Key,
            //                  Count = allHit.Count()
            //              } into uniqueHit
            //              orderby uniqueHit.Count descending
            //              select uniqueHit.Name.PostId)
            //              .Take(limit)
            //              .ToListAsync();
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
