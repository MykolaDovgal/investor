using System.Linq;
using AutoMapper;
using Investor.Entity;
using Investor.Model;
using Investor.ViewModel;

namespace Investor.Service.Mapper
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogViewModel, BlogEntity>()
                .ReverseMap()
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
            CreateMap<BlogEntity, BlogPreview>();
            CreateMap<BlogEntity, TableBlogPreview>().ReverseMap();
            CreateMap<BlogEntity, Blog>()
                .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag)));

            CreateMap<Blog, BlogEntity>()
                .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                .ForMember(x => x.PostTags, opt => opt.Ignore())
                .ForMember(x => x.ModifiedOn, opt => opt.Ignore())
                .ForMember(x => x.PublishedOn, opt => opt.Ignore())
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

            CreateMap<BlogEntity, BlogEntity>()
                .ForMember(x => x.Author, opt => opt.Ignore())
                .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                .ForMember(x => x.PublishedOn, opt => opt.Ignore())
                .ForMember(x => x.ModifiedOn, opt => opt.Ignore())
                .ForMember(x => x.PostTags, opt => opt.Ignore())
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));   
        }
    }
}
