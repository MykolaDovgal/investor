﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Investor.Entity;
using Investor.Model;


namespace Investor.Service.Mapper
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
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
