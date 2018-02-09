using AutoMapper;
using Investor.Model;
using Investor.ViewModel;

namespace Investor.Web.Mapper
{
    public class PostSearchQueryMappingProfile : Profile
    {
        public PostSearchQueryMappingProfile()
        {
            CreateMap<PostSearchQuery, PostSearchQueryViewModel>().ReverseMap();
        }
    }
}
