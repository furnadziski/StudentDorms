using AutoMapper;
using StudentDorms.Domain.Config;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
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

            CreateMap<DropdownViewModel<int>, UserRole>()
                 .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
                      .ReverseMap()
                 .ForPath(d => d.Title, o => o.MapFrom(src => src.Role.Name));

            
            CreateMap<DropdownViewModel<int>, AnnualAccommodationUser>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                     .ReverseMap()
                    .ForMember(dest => dest.Title,
                       opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));

            CreateMap<DropdownViewModel<int>, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName,
                       opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.LastName,
                       opt => opt.MapFrom(src => src.Title))
            .ReverseMap()
            .ForMember(dest => dest.Title,
                       opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<UserViewModel, UserRole > ()
             .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Roles))
                             .ReverseMap();
        
            CreateMap<DropdownViewModel<int>, Role>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                 .ReverseMap();
                   
            CreateMap<DropdownViewModel<int>, MealCategory>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
              .ReverseMap();

            CreateMap<DropdownViewModel<int>, Meal>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
            .ReverseMap();

            CreateMap<DropdownViewModel<int>, Block>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                 .ReverseMap();
            
            CreateMap<DropdownViewModel<int>, StudentDorm>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
               .ReverseMap();

            
            CreateMap<DropdownViewModel<int>, Gender>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
               .ReverseMap();
            CreateMap<DropdownViewModel<int>, Room>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.RoomNo, opt => opt.MapFrom(src => src.Title))
              .ReverseMap();


            CreateMap<StudentDorm, Block>()
                  .ForMember(dest => dest.StudentDormId, opt => opt.MapFrom(src => src.Id))
                  .ReverseMap();


            CreateMap<UserCreateUpdateModel, User>()
                   .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
                   .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.Roles))
                   .ReverseMap();

            CreateMap<AccommodationCreateUpdateModel, AnnualAccommodation>()
                .ForMember(dest => dest.AnnualAccommodationUsers, opt => opt.MapFrom(src => src.Users))
                             .ReverseMap();


            CreateMap<RoomCreateUpdateModel, Room>()
                   .ReverseMap();

            CreateMap<WeeklyMealCreateUpdateModel,WeeklyMeal>()
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

            CreateMap<BlockViewModel, Block>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
              .ForMember(dest => dest.StudentDormId, opt => opt.MapFrom(src => src.StudentDorm.Id))
               .ReverseMap();

            CreateMap<MealViewModel, Meal>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
            .ForMember(dest => dest.MealCategoryId, opt => opt.MapFrom(src => src.MealCategory.Id))
                    .ReverseMap();

            CreateMap<RoomViewModel, Room>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));
            //.ReverseMap();

            CreateMap<AccommodationViewModel, AnnualAccommodation>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
         .ForMember(dest => dest.AnnualAccommodationUsers, opt => opt.MapFrom(src => src.Students));

            CreateMap<AccommodationViewModel, AnnualAccommodationUser>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
         

            .ReverseMap();
            CreateMap<RoomGridModel, Room>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
            .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.BlockName))
            .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
            .ForMember(dest => dest.RoomNo, opt => opt.MapFrom(src => src.Name))
                    .ReverseMap();




            CreateMap<AccommodationGridModel, AnnualAccommodation>()
                          .ReverseMap();

            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                                 .ReverseMap();

                   CreateMap<DropdownViewModel<int>, Restaurant>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}
