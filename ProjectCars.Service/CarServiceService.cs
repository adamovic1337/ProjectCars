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
using ProjectCars.Repository.Helpers;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Helpers;
using ProjectCars.Service.Validation;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;

namespace ProjectCars.Service
{
    public class CarServiceService : ICarServiceService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<CarService> _carServiceRepository;
        private readonly IMapper _mapper;
        private readonly CreateCarServiceValidator _createCarServiceValidator;
        private readonly UpdateCarServiceValidator _updateCarServiceValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CarServiceService(IUnitOfWork unitOfWork, IGenericRepository<CarService> carServiceRepository, IMapper mapper, CreateCarServiceValidator createCarServiceValidator, UpdateCarServiceValidator updateCarServiceValidator)
        {
            _unitOfWork = unitOfWork;
            _carServiceRepository = carServiceRepository;
            _mapper = mapper;
            _createCarServiceValidator = createCarServiceValidator;
            _updateCarServiceValidator = updateCarServiceValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public IEnumerable<CarServiceDto> GetCarServices(SearchCarServiceDto searchCarService)
        {
            var orderBy = searchCarService.OrderBy.Split(new[] { '-' })[0];
            var direction = searchCarService.OrderBy?.Split(new[] { '-' })[1];

            var carServices = _carServiceRepository.GetAll(searchCarService.PageNumber, searchCarService.PageSize,
                cs => cs.Name.Contains(Strings.Trim(searchCarService.CarServiceName)),
                q => q.OrderBy($"{orderBy} {direction}"));

            return _mapper.Map<IEnumerable<CarServiceDto>>(carServices);
        }

        public PagedList<CarService> PagedListCarServices(SearchCarServiceDto searchCarService)
        {
            return _carServiceRepository.GetAll(searchCarService.PageNumber, searchCarService.PageSize, r => r.Name.Contains(Strings.Trim(searchCarService.CarServiceName)));
        }

        public CarServiceDto GetCarServiceById(int carServiceId)
        {
            var carService = _carServiceRepository.GetOne(carServiceId).EntityNotFoundCheck();

            return _mapper.Map<CarServiceDto>(carService);
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
            var carService = _carServiceRepository.GetOne(carServiceId).EntityNotFoundCheck();

            _updateCarServiceValidator.ValidateAndThrow(carServiceDto);
            _carServiceRepository.Update(carService);
            _mapper.Map(carServiceDto, carService);
            _unitOfWork.Commit();
        }

        public void UpdateCarServicePatch(int carServiceId, JsonPatchDocument<UpdateCarServiceDto> patchDocument)
        {
            var carService = _carServiceRepository.GetOne(carServiceId).EntityNotFoundCheck();

            var carServiceDto = _mapper.Map<UpdateCarServiceDto>(carService);

            patchDocument.ApplyTo(carServiceDto);

            _updateCarServiceValidator.ValidateAndThrow(carServiceDto);
            _carServiceRepository.Update(carService);
            _mapper.Map(carServiceDto, carService);
            _unitOfWork.Commit();
        }

        public void DeleteCarService(int carServiceId)
        {
            _carServiceRepository.GetOne(carServiceId).EntityNotFoundCheck();

            _carServiceRepository.Delete(carServiceId);
            _unitOfWork.Commit();
        }
    }

    #endregion METHODS
}