using AutoMapper;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;

namespace ProjectCars.Service.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDto>();
            CreateMap<CreateUserDto, AppUser>();
            CreateMap<UpdateUserDto, AppUser>();
            CreateMap<AppUser, UpdateUserDto>();
        }
    }
}