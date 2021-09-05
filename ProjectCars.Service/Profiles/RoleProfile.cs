using AutoMapper;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;

namespace ProjectCars.Service.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AppRole, RoleDto>();
            CreateMap<CreateRoleDto, AppRole>();
            CreateMap<UpdateRoleDto, AppRole>();
            CreateMap<AppRole, UpdateRoleDto>();
        }
    }
}