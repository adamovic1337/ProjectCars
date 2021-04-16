using AutoMapper;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;

namespace ProjectCars.Service.Profiles
{
    public class FuelTypeProfile : Profile
    {
        public FuelTypeProfile()
        {
            CreateMap<FuelType, FuelTypeDto>();
            CreateMap<CreateFuelTypeDto, FuelType>();
            CreateMap<UpdateFuelTypeDto, FuelType>();
            CreateMap<FuelType, UpdateFuelTypeDto>();
        }
    }
}
