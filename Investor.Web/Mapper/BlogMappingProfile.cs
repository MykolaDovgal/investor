using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investor.Model;
using Investor.ViewModel;

namespace Investor.Web.Mapper
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogViewModel, Blog>()
                .ForMember(s => s.Category, opt => opt.Ignore())
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
            CreateMap<string, Tag>()
                .ForMember(s => s.Name, opt => opt.MapFrom(s => s));
        }
    }
}
