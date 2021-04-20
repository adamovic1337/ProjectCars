using AutoMapper;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;

namespace ProjectCars.Service.Profiles
{
    public class EngineProfile : Profile
    {
        public EngineProfile()
        {
            CreateMap<Engine, EngineDto>();
            CreateMap<CreateEngineDto, Engine>();
            CreateMap<UpdateEngineDto, Engine>();
            CreateMap<Engine, UpdateEngineDto>();
        }
    }
}
