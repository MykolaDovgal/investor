using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Investor.Entity;
using Investor.Model;

namespace Investor.Service.Mapper
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            CreateMap<Tag, TagEntity>().ReverseMap();
            CreateMap<AdminTag, TagEntity>().ReverseMap();
        }
    }
}
