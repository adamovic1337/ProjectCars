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
    public class FuelTypeService : IFuelTypeService
    {
        #region FIELDS

        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly IMapper _mapper;
        private readonly CreateFuelTypeValidator _createFuelTypeValidator;
        private readonly UpdateFuelTypeValidator _updateFuelTypeValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public FuelTypeService(IFuelTypeRepository fuelTypeRepository, IMapper mapper, CreateFuelTypeValidator createFuelTypeValidator, UpdateFuelTypeValidator updateFuelTypeValidator)
        {
            _fuelTypeRepository = fuelTypeRepository;
            _mapper = mapper;
            _createFuelTypeValidator = createFuelTypeValidator;
            _updateFuelTypeValidator = updateFuelTypeValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<FuelTypeDto> GetFuelTypes(SearchFuelTypeDto searchFuelType)
        {
            return _fuelTypeRepository.GetAll(searchFuelType);
        }

        public PaginationData<FuelType> PaginationData(SearchFuelTypeDto searchFuelType)
        {
            return _fuelTypeRepository.GetPaginationData(searchFuelType,
                                                         r => r.Name.Contains(searchFuelType.FuelTypeName.Trim()));
        }

        public FuelTypeDto GetFuelTypeById(int fuelTypeId)
        {
            return _fuelTypeRepository.GetOne(fuelTypeId).EntityNotFoundCheck();
        }

        public FuelTypeDto CreateFuelType(CreateFuelTypeDto fuelTypeDto)
        {
            _createFuelTypeValidator.ValidateAndThrow(fuelTypeDto);

            var fuelTypeEntity = _mapper.Map<FuelType>(fuelTypeDto);
            _fuelTypeRepository.Create(fuelTypeEntity);
            _fuelTypeRepository.Save();

            var fuelTypeToReturn = _mapper.Map<FuelTypeDto>(fuelTypeEntity);
            return fuelTypeToReturn;
        }

        public void UpdateFuelTypePut(int fuelTypeId, UpdateFuelTypeDto fuelTypeDto)
        {
            var fuelType = _fuelTypeRepository.GetEntity(fuelTypeId).EntityNotFoundCheck();

            fuelTypeDto.Id = fuelTypeId;

            _updateFuelTypeValidator.ValidateAndThrow(fuelTypeDto);
            _fuelTypeRepository.Update(fuelType);
            _mapper.Map(fuelTypeDto, fuelType);
            _fuelTypeRepository.Save();
        }

        public void UpdateFuelTypePatch(int fuelTypeId, JsonPatchDocument<UpdateFuelTypeDto> patchDocument)
        {
            var fuelType = _fuelTypeRepository.GetEntity(fuelTypeId).EntityNotFoundCheck();

            var fuelTypeDto = _mapper.Map<UpdateFuelTypeDto>(fuelType);

            patchDocument.ApplyTo(fuelTypeDto);

            fuelTypeDto.Id = fuelTypeId;

            _updateFuelTypeValidator.ValidateAndThrow(fuelTypeDto);
            _fuelTypeRepository.Update(fuelType);
            _mapper.Map(fuelTypeDto, fuelType);
            _fuelTypeRepository.Save();
        }

        public void DeleteFuelType(int fuelTypeId)
        {
            var fuelType = _fuelTypeRepository.GetEntity(fuelTypeId).EntityNotFoundCheck();

            _fuelTypeRepository.Delete(fuelType);
            _fuelTypeRepository.Save();
        }

        #endregion METHODS
    }
}