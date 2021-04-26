using AutoMapper;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;

namespace ProjectCars.Service.Profiles
{
    public class CarServiceProfile : Profile
    {
        public CarServiceProfile()
        {
            CreateMap<CarService, CarServiceDto>();
            CreateMap<CreateCarServiceDto, CarService>();
            CreateMap<UpdateCarServiceDto, CarService>();
            CreateMap<CarService, UpdateCarServiceDto>();
        }
    }
}
