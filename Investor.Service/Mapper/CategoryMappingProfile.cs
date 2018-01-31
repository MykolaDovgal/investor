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
