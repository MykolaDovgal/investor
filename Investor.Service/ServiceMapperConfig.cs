using AutoMapper;
using Investor.Entity;
using Investor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Investor.Service
{
    class ServiceMapperConfig 
    {
        public void Config()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Article, ArticleEntity>().ReverseMap();
                cfg.CreateMap<Category, CategoryEntity>().ReverseMap();
                cfg.CreateMap<Comment, CommentEntity>().ReverseMap();
                cfg.CreateMap<Tag, TagEntity>().ReverseMap();
                cfg.CreateMap<SliderItem, SliderItemEntity>().ReverseMap();
                cfg.CreateMap<PostEntity, Post>()
                     .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag))).ReverseMap();
                cfg.CreateMap<User, UserEntity>().ReverseMap();
            });
                 
        }
    }
}
