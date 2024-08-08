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

            CreateMap<DropdownViewModel<int>, Role>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                 .ReverseMap();

            CreateMap<DropdownViewModel<int>, Gender>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
               .ReverseMap();

            CreateMap<StudentDorm, Block>()
                  .ForMember(dest => dest.StudentDormId, opt => opt.MapFrom(src => src.Id))
                  .ReverseMap();

            CreateMap<RoomCreateUpdateModel, Room>()
                   .ReverseMap();

            CreateMap<MealCreateUpdateModel, Meal>()
                   .ReverseMap();

            CreateMap<StudentDormCreateUpdateModel, StudentDorm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<BlockCreateUpdateModel, Block>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(dest => dest.StudentDormId, opt => opt.MapFrom(src => src.StudentDormId))
                .ReverseMap();

            CreateMap<DropdownViewModel<int>, Restaurant>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}
