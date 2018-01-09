using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Investor.Entity;
using Investor.Model;
using Investor.Repository.Interfaces;
using Investor.Service.Interfaces;

namespace Investor.Service
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task AddStatisticsAsync(Statistics statistics)
        {
            await _statisticsRepository.AddStatistics(Mapper.Map<Statistics, StatisticsEntity>(statistics));
        }

        public async Task<int> GetPostViewsCountByIdAsync(int postId,bool isUnique = false)
        {
            return await _statisticsRepository.GetPostViewsCountByIdAsync(postId, isUnique);
        }
    }
}
