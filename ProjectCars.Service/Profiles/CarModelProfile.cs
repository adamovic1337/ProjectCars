using AutoMapper;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;

namespace ProjectCars.Service.Profiles
{
    public class CarModelProfile : Profile
    {
        public CarModelProfile()
        {
            CreateMap<CarModel, CarModelDto>();
            CreateMap<CreateCarModelDto, CarModel>();
            CreateMap<UpdateCarModelDto, CarModel>();
            CreateMap<CarModel, UpdateCarModelDto>();
        }
    }
}