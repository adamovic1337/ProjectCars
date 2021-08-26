using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.VisualBasic;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
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

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarServiceRepository _carServiceRepository;
        private readonly IMapper _mapper;
        private readonly CreateCarServiceValidator _createCarServiceValidator;
        private readonly UpdateCarServiceValidator _updateCarServiceValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CarServiceService(IUnitOfWork unitOfWork, ICarServiceRepository carServiceRepository, IMapper mapper, CreateCarServiceValidator createCarServiceValidator, UpdateCarServiceValidator updateCarServiceValidator)
        {
            _unitOfWork = unitOfWork;
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
                                                           r => r.Name.Contains(Strings.Trim(searchCarService.CarServiceName)));
        }

        public CarServiceDto GetCarServiceById(int carServiceId)
        {
            return _carServiceRepository.GetOne(carServiceId).EntityNotFoundCheck();
        }

        public CarServiceDto CreateCarService(CreateCarServiceDto carServiceDto)
        {
            _createCarServiceValidator.ValidateAndThrow(carServiceDto);

            var carServiceEntity = _mapper.Map<CarService>(carServiceDto);
            _carServiceRepository.Create(carServiceEntity);
            _unitOfWork.Commit();

            var carServiceToReturn = _mapper.Map<CarServiceDto>(carServiceEntity);
            return carServiceToReturn;
        }

        public void UpdateCarServicePut(int carServiceId, UpdateCarServiceDto carServiceDto)
        {
            var carService = _carServiceRepository.GetForUpdate(carServiceId).EntityNotFoundCheck();

            carServiceDto.Id = carServiceId;

            _updateCarServiceValidator.ValidateAndThrow(carServiceDto);
            _carServiceRepository.Update(carService);
            _mapper.Map(carServiceDto, carService);
            _unitOfWork.Commit();
        }

        public void UpdateCarServicePatch(int carServiceId, JsonPatchDocument<UpdateCarServiceDto> patchDocument)
        {
            var carService = _carServiceRepository.GetForUpdate(carServiceId).EntityNotFoundCheck();

            var carServiceDto = _mapper.Map<UpdateCarServiceDto>(carService);

            patchDocument.ApplyTo(carServiceDto);

            carServiceDto.Id = carServiceId;

            _updateCarServiceValidator.ValidateAndThrow(carServiceDto);
            _carServiceRepository.Update(carService);
            _mapper.Map(carServiceDto, carService);
            _unitOfWork.Commit();
        }

        public void DeleteCarService(int carServiceId)
        {
            _carServiceRepository.GetForUpdate(carServiceId).EntityNotFoundCheck();

            _carServiceRepository.Delete(carServiceId);
            _unitOfWork.Commit();
        }
    }

    #endregion METHODS
}