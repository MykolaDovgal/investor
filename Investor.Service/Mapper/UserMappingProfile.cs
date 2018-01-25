using System;
using System.Linq;
using AutoMapper;
using Investor.Entity;
using Investor.Model;
using Investor.ViewModel;

namespace Investor.Service.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserDescriptionViewModel, UserEntity>()
                .ForMember(x => x.SerializedSocials, opt => opt.MapFrom(src => string.Join(";", src.Socials)))
                .ForMember(x => x.SerializedCropPoints, opt => opt.MapFrom(src => string.Join(";", src.CropPoints)))
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));

            CreateMap<User, UserEntity>()
                .ForMember(x => x.SerializedSocials, opt => opt.MapFrom(src => string.Join(";", src.Socials)))
                .ForMember(x => x.SerializedCropPoints, opt => opt.MapFrom(src => string.Join(";", src.CropPoints)))
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
            CreateMap<UserPasswordChangeViewModel, UserEntity>();
            CreateMap<UserPersonalDataViewModel, UserEntity>();
            CreateMap<UserEntity, TableUserPreview>().ForMember(x => x.NumberOfBlogs, opt => opt.MapFrom(src => src.Blogs.Count));
            CreateMap<TableUserPreview, UserEntity>();
            CreateMap<UserEntity, User>()
                .ForMember(x => x.Socials, opt => opt.MapFrom(src => src.SerializedSocials.Split(';', StringSplitOptions.None)))
                .ForMember(x => x.CropPoints, opt => opt.MapFrom(src => src.SerializedCropPoints.Split(';', StringSplitOptions.None).Select(int.Parse)))
                .ForAllMembers(p => p.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
            CreateMap<RegisterViewModel, User>().ReverseMap();
        }
    }
}
