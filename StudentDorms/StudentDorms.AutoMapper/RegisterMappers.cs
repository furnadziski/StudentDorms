using AutoMapper;
using StudentDorms.Domain.Config;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.Shared;
using StudentDorms.Models.ViewModels;
using StudentDorms.Settings;

namespace StudentDorms.AutoMapper
{
    public class RegisterMappers : Profile
    {
        public RegisterMappers()
        {
            CreateMap<AppSettings, AppSettingsModel>().ReverseMap();

            CreateMap<RestaurantCreateUpdateModel, Restaurant>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                   .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
                   .ForMember(dest => dest.Participation, opt => opt.MapFrom(src => src.Participation))
                   .ReverseMap();

            CreateMap<DropdownViewModel<int>, Restaurant>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}
