using AutoMapper;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;

namespace ProjectCars.Service.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>();
            
        }
    }
}