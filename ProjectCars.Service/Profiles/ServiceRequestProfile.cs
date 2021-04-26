using AutoMapper;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;

namespace ProjectCars.Service.Profiles
{
    public class ServiceRequestProfile : Profile
    {
        public ServiceRequestProfile()
        {
            CreateMap<ServiceRequest, ServiceRequestDto>();
            CreateMap<CreateServiceRequestDto, ServiceRequest>();
            CreateMap<UpdateServiceRequestDto, ServiceRequest>();
            CreateMap<ServiceRequest, UpdateServiceRequestDto>();
        }
    }
}
