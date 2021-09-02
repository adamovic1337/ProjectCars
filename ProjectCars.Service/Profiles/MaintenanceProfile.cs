using AutoMapper;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;

namespace ProjectCars.Service.Profiles
{
    public class MaintenanceProfile : Profile
    {
        public MaintenanceProfile()
        {
            CreateMap<Maintenance, MaintenanceDto>();
            CreateMap<CreateMaintenanceDto, Maintenance>();
            CreateMap<UpdateMaintenanceDto, Maintenance>();
            CreateMap<Maintenance, UpdateMaintenanceDto>();
        }
    }
}
