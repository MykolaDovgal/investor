using AutoMapper;
using Investor.Model;
using Investor.ViewModel;
using Microsoft.AspNetCore.Http;

namespace Investor.Web.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserDescriptionViewModel, User>()
                .ReverseMap()
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
            CreateMap<UserPasswordChangeViewModel, User>();
            CreateMap<User, UserPasswordChangeViewModel>()
                .ForMember(c => c.Password, opt => opt.Ignore())
                .ForMember(c => c.NewConfirmedPassword, opt => opt.Ignore())
                .ForMember(c => c.NewPassword, opt => opt.Ignore());
            CreateMap<UserPersonalDataViewModel, User>().ReverseMap();
            CreateMap<RegisterViewModel, User>().ReverseMap();
            CreateMap<string, IFormFile>()
                .ForMember(c => c.Name, opt => opt.MapFrom(s => s))
                .ReverseMap();
        }
    }
}
