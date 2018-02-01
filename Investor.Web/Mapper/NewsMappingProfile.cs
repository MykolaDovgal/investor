using AutoMapper;
using Investor.Model;
using Investor.ViewModel;

namespace Investor.Web.Mapper
{
    public class NewsMappingProfile : Profile
    {
        public NewsMappingProfile()
        {
            CreateMap<NewsViewModel, News>()
                .ForMember(s=>s.Category, opt=>opt.Ignore())
                .ForMember(s=>s.Tags, opt=>opt.Ignore())
                .ForMember(s=>s.PublishedOn, opt=>opt.Ignore())
                .ForMember(s=>s.CreatedOn, opt=>opt.Ignore())
                .ReverseMap()
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
        }
    }
}
