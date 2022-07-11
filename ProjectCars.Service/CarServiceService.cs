using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.Helpers;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Helpers;
using ProjectCars.Service.Validation;
using System.Collections.Generic;

namespace ProjectCars.Service
{
    public class CarServiceService : ICarServiceService
    {
        #region FIELDS

        private readonly ICarServiceRepository _carServiceRepository;
        private readonly IMapper _mapper;
        private readonly CreateCarServiceValidator _createCarServiceValidator;
        private readonly UpdateCarServiceValidator _updateCarServiceValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CarServiceService(ICarServiceRepository carServiceRepository, IMapper mapper, CreateCarServiceValidator createCarServiceValidator, UpdateCarServiceValidator updateCarServiceValidator)
        {
            _carServiceRepository = carServiceRepository;
            _mapper = mapper;
            _createCarServiceValidator = createCarServiceValidator;
            _updateCarServiceValidator = updateCarServiceValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<CarServiceDto> GetCarServices(SearchCarServiceDto searchCarService)
        {
            return _carServiceRepository.GetAll(searchCarService);
        }

        public PaginationData<CarService> PaginationData(SearchCarServiceDto searchCarService)
        {
            return _carServiceRepository.GetPaginationData(searchCarService,
                                                           r => r.Name.Contains(searchCarService.CarServiceName.Trim()));
        }

        public CarServiceDto GetCarServiceById(int carServiceId)
        {
            return _carServiceRepository.GetOne(carServiceId).EntityNotFoundCheck();
        }

        public CarServiceDto GetCarServiceByOwnerId(int ownderId)
        {
            return _carServiceRepository.GetOneByOwner(ownderId).EntityNotFoundCheck();
        }

        public CarServiceDto CreateCarService(CreateCarServiceDto carServiceDto)
        {
            _createCarServiceValidator.ValidateAndThrow(carServiceDto);

            var carServiceEntity = _mapper.Map<CarService>(carServiceDto);
            _carServiceRepository.Create(carServiceEntity);
            _carServiceRepository.Save();

            var carServiceToReturn = _mapper.Map<CarServiceDto>(carServiceEntity);
            return carServiceToReturn;
        }

        public void UpdateCarServicePut(int carServiceId, UpdateCarServiceDto carServiceDto)
        {
            var carService = _carServiceRepository.GetEntity(carServiceId).EntityNotFoundCheck();

            carServiceDto.Id = carServiceId;

            _updateCarServiceValidator.ValidateAndThrow(carServiceDto);
            _carServiceRepository.Update(carService);
            _mapper.Map(carServiceDto, carService);
            _carServiceRepository.Save();
        }

        public void UpdateCarServicePatch(int carServiceId, JsonPatchDocument<UpdateCarServiceDto> patchDocument)
        {
            var carService = _carServiceRepository.GetEntity(carServiceId).EntityNotFoundCheck();

            var carServiceDto = _mapper.Map<UpdateCarServiceDto>(carService);

            patchDocument.ApplyTo(carServiceDto);

            carServiceDto.Id = carServiceId;

            _updateCarServiceValidator.ValidateAndThrow(carServiceDto);
            _carServiceRepository.Update(carService);
            _mapper.Map(carServiceDto, carService);
            _carServiceRepository.Save();
        }

        public void DeleteCarService(int carServiceId)
        {
            var carService = _carServiceRepository.GetEntity(carServiceId).EntityNotFoundCheck();

            _carServiceRepository.Delete(carService);
            _carServiceRepository.Save();
        }
    }

    #endregion METHODS
}