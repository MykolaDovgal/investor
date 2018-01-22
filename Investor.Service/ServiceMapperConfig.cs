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
                    .ForMember(x => x.SerializedSocials, opt => opt.MapFrom(src => string.Join(";", src.Socials)))
                    .ForMember(x => x.SerializedCropPoints, opt => opt.MapFrom(src => string.Join(";", src.CropPoints)))
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
                cfg.CreateMap<UserEntity, TableUserPreview>().ForMember(x=>x.NumberOfBlogs, opt => opt.MapFrom(src => src.Blogs.Count));
                cfg.CreateMap<TableUserPreview, UserEntity>();
                cfg.CreateMap<UserEntity, User>()
                    .ForMember(x => x.Socials, opt => opt.MapFrom(src => src.SerializedSocials.Split(';',StringSplitOptions.None)))
                    .ForMember(x=>x.CropPoints, opt => opt.MapFrom(src=>src.SerializedCropPoints.Split(';', StringSplitOptions.None).Select(int.Parse)))
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
                cfg.CreateMap<RegisterViewModel, User>().ReverseMap();

                cfg.CreateMap<Category, CategoryEntity>().ReverseMap();

                cfg.CreateMap<Tag, TagEntity>().ReverseMap();
                cfg.CreateMap<AdminTag, TagEntity>().ReverseMap();

                cfg.CreateMap<PostPreview, PostEntity>().ReverseMap();

                cfg.CreateMap<BlogEntity, BlogPreview>();
                cfg.CreateMap<BlogEntity, TableBlogPreview>().ReverseMap();

                cfg.CreateMap<NewsEntity, PostPreview>().ReverseMap();
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
                    .ForMember(x => x.ModifiedOn, opt => opt.Ignore())
                    .ForMember(x => x.PostTags, opt => opt.Ignore())
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

                cfg.CreateMap<NewsEntity, News>()
                    .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag)))
                    .ReverseMap();

                cfg.CreateMap<IList<PostEntity>, IList<News>>().ReverseMap();

                cfg.CreateMap<Statistics, StatisticsEntity>().ReverseMap();


            });

        }
    }
}
