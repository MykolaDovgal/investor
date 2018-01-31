using AutoMapper;
using Investor.Entity;
using Investor.Model;

namespace Investor.Service.Mapper
{
    public class StatisticsMappingProfile : Profile
    {
        public StatisticsMappingProfile()
        {
            CreateMap<Statistics, StatisticsEntity>().ReverseMap();
        }
    }
}
