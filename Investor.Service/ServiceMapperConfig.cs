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
                    .ForMember(x => x.Socials, opt => opt.MapFrom(src => src.SerializedSocials.Split(';',StringSplitOptions.RemoveEmptyEntries)));
                cfg.CreateMap<Article, ArticleEntity>().ReverseMap();
                cfg.CreateMap<RegisterViewModel, User>().ReverseMap();
                cfg.CreateMap<Category, CategoryEntity>().ReverseMap();
                cfg.CreateMap<Comment, CommentEntity>().ReverseMap();
                cfg.CreateMap<Tag, TagEntity>().ReverseMap();
                cfg.CreateMap<SliderItem, SliderItemEntity>().ReverseMap();
                cfg.CreateMap<PostEntity, PostPreview>().ReverseMap();
                cfg.CreateMap<PostEntity, BlogPreview>().ReverseMap();
                cfg.CreateMap<PostEntity, TablePostPreview>().ReverseMap();
                cfg.CreateMap<PostEntity, Post>()
                    .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag)));
                cfg.CreateMap<IList<PostEntity>, IList<Post>>().ReverseMap();
            });

        }
    }
}
