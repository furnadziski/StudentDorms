using AutoMapper;
using StudentDorms.Domain.Config;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.Shared;
using StudentDorms.Models.ViewModels;
using StudentDorms.Settings;
using System.Collections;
using System.Collections.Generic;

namespace StudentDorms.AutoMapper
{
    public class RegisterMappers : Profile
    {
        public RegisterMappers()
        {
            CreateMap<AppSettings, AppSettingsModel>().ReverseMap();


            CreateMap<UserCreateUpdateModel, User>()
                   .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
                   .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.Roles))
                   .ReverseMap();

            CreateMap<DropdownViewModel<int>, UserRole>()
                 .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
                 .ReverseMap();

            CreateMap<DropdownViewModel<int>, Restaurant>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}
