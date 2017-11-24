using AutoMapper;
using Investor.Entity;
using Investor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Investor.Model.Views;

namespace Investor.Service
{
    public class ServiceMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserEntity>()
                    .ForMember(x => x.SerializedSocials, opt => opt.MapFrom(src => string.Join(";", src.Socials)));
                cfg.CreateMap<UserEntity, User>()
                    .ForMember(x => x.Socials, opt => opt.MapFrom(src => src.SerializedSocials.Split(';', StringSplitOptions.RemoveEmptyEntries)));
                cfg.CreateMap<RegisterViewModel, User>().ReverseMap();
                cfg.CreateMap<Category, CategoryEntity>().ReverseMap();
                cfg.CreateMap<Tag, TagEntity>().ReverseMap();
                cfg.CreateMap<AdminTag, TagEntity>().ReverseMap();
                cfg.CreateMap<TableBlogPreview, PostEntity>().ReverseMap();

                cfg.CreateMap<PostPreview, PostEntity>().ReverseMap();
                cfg.CreateMap<NewsEntity, PostPreview>()
                    .ForMember(dto => dto.Image, opt => opt.ResolveUsing(s => String.IsNullOrWhiteSpace(s.Image) ? $"no-img/no-img-{s.Category.Url}.png" : s.Image))
                    .ReverseMap();

                cfg.CreateMap<BlogEntity, BlogPreview>()
                    .ForMember(dto => dto.Image, opt => opt.ResolveUsing(s => String.IsNullOrWhiteSpace(s.Image) ? $"no-img/no-img-blog.png" : s.Image));


                cfg.CreateMap<NewsEntity, TablePostPreview>().ReverseMap();
                cfg.CreateMap<News, PostPreview>();
                cfg.CreateMap<News, PostEntity>()
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

                cfg.CreateMap<NewsEntity, NewsEntity>()
                .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                .ForMember(x => x.PostTags, opt => opt.Ignore())
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

                cfg.CreateMap<News, News>()
                    .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                    .ForMember(x => x.Tags, opt => opt.Ignore())
                    .ForMember(x => x.ModifiedOn, opt => opt.Ignore())
                    .ForMember(x => x.PublishedOn, opt => opt.Ignore())
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

                cfg.CreateMap<BlogEntity, Blog>()
                    .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag)));

                cfg.CreateMap<Blog, BlogEntity>()
                    .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                    .ForMember(x => x.PostTags, opt => opt.Ignore())
                    .ForMember(x => x.ModifiedOn, opt => opt.Ignore())
                    .ForMember(x => x.PublishedOn, opt => opt.Ignore())
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
                
                    

                cfg.CreateMap<BlogEntity, BlogEntity>()
                    .ForMember(x=>x.Author, opt=>opt.Ignore())
                    .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                    .ForMember(x => x.PublishedOn, opt => opt.Ignore())
                    .ForMember(x => x.PostTags, opt => opt.Ignore())
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

                cfg.CreateMap<NewsEntity, News>()
                    .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag)))
                    .ForMember(dto => dto.Image, opt => opt.ResolveUsing(s => String.IsNullOrWhiteSpace(s.Image) ? $"no-img/no-img-{s.Category.Url}.png" : s.Image))
                    .ReverseMap();

                cfg.CreateMap<IList<PostEntity>, IList<News>>().ReverseMap();
            });

        }
    }
}
