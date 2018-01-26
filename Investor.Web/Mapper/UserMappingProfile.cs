using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investor.Model;
using Investor.ViewModel;

namespace Investor.Web.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserDescriptionViewModel, User>()
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
            CreateMap<UserPasswordChangeViewModel, User>();
            CreateMap<UserPersonalDataViewModel, User>();
            CreateMap<RegisterViewModel, User>().ReverseMap();
        }
    }
}
