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
                cfg.CreateMap<Article, ArticleEntity>().ReverseMap();
                cfg.CreateMap<RegisterViewModel, User>().ReverseMap();
                cfg.CreateMap<Category, CategoryEntity>().ReverseMap();
                cfg.CreateMap<Comment, CommentEntity>().ReverseMap();
                cfg.CreateMap<Tag, TagEntity>().ReverseMap();
                cfg.CreateMap<AdminTag, TagEntity>().ReverseMap();
                cfg.CreateMap<SliderItem, SliderItemEntity>().ReverseMap();
                cfg.CreateMap<TableBlogPreview, PostEntity>().ReverseMap();

                cfg.CreateMap<PostPreview, PostEntity>();
                cfg.CreateMap<PostEntity, PostPreview>()
                    .ForMember(dto => dto.Image, opt => opt.ResolveUsing(s => String.IsNullOrWhiteSpace(s.Image) ? $"no-img/no-img-{s.Category.Url}.png" : s.Image));

                cfg.CreateMap<PostEntity, BlogPreview>()
                    .ForMember(dto => dto.Image, opt => opt.ResolveUsing(s => String.IsNullOrWhiteSpace(s.Image) ? $"no-img/no-img-{s.Category.Url}.png" : s.Image));


                cfg.CreateMap<PostEntity, TablePostPreview>();
                cfg.CreateMap<Post, PostPreview>();
                cfg.CreateMap<Post, PostEntity>()
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

                cfg.CreateMap<PostEntity, PostEntity>()
                .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                .ForMember(x => x.PostTags, opt => opt.Ignore())
                .ForMember(x => x.IsBlogPost, opt => opt.Ignore())
                .ForMember(x => x.Author, opt => opt.Ignore())
                .ForMember(x => x.AuthorId, opt => opt.Ignore())
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

                cfg.CreateMap<Post, Post>()
                    .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                    .ForMember(x => x.Tags, opt => opt.Ignore())
                    .ForMember(x => x.ModifiedOn, opt => opt.Ignore())
                    .ForMember(x => x.PublishedOn, opt => opt.Ignore())
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

                cfg.CreateMap<SliderItem, SliderItem>()
                    .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

                cfg.CreateMap<PostEntity, Blog>()
                    .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag)));

                cfg.CreateMap<PostEntity, Post>()
                    .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag)))
                    .ForMember(dto => dto.Image, opt => opt.ResolveUsing(s => String.IsNullOrWhiteSpace(s.Image) ? $"no-img/no-img-{s.Category.Url}.png" : s.Image));

                cfg.CreateMap<IList<PostEntity>, IList<Post>>().ReverseMap();
            });

        }
    }
}
