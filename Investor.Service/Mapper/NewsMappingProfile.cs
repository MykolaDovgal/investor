using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Investor.Entity;
using Investor.Model;
using Investor.ViewModel;

namespace Investor.Service.Mapper
{
    public class NewsMappingProfile : Profile
    {
        public NewsMappingProfile()
        {
            CreateMap<NewsEntity, PostPreview>().ReverseMap();
            CreateMap<NewsEntity, TablePostPreview>().ReverseMap();
            CreateMap<News, PostPreview>();
            CreateMap<News, PostEntity>()
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
            CreateMap<NewsEntity, NewsEntity>()
                .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                .ForMember(s => s.PublishedOn, opt=>opt.Ignore())
                .ForMember(s => s.ModifiedOn,  opt => opt.Ignore())
                .ForMember(x => x.PostTags, opt => opt.Ignore())
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
            CreateMap<News, News>()
                .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                .ForMember(x => x.Tags, opt => opt.Ignore())
                .ForMember(x => x.ModifiedOn, opt => opt.Ignore())
                .ForMember(x => x.PublishedOn, opt => opt.Ignore())
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
            CreateMap<NewsEntity, News>()
                .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag)))
                .ReverseMap();

            //CreateMap<NewsViewModel, NewsEntity>().ReverseMap()
            //    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

            //CreateMap<News, NewsViewModel>().ReverseMap();

            CreateMap<IList<PostEntity>, IList<News>>().ReverseMap();
            CreateMap<PostPreview, PostEntity>().ReverseMap();
        }
    }
}
