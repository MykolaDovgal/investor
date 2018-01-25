using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Investor.Entity;
using Investor.Model;

namespace Investor.Service.Mapper
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryEntity>().ReverseMap();
        }
    }
}
