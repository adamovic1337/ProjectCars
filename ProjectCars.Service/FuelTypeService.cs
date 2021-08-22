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
    public class FuelTypeService : IFuelTypeService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<FuelType> _fuelTypeRepository;
        private readonly IMapper _mapper;
        private readonly CreateFuelTypeValidator _createFuelTypeValidator;
        private readonly UpdateFuelTypeValidator _updateFuelTypeValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public FuelTypeService(IUnitOfWork unitOfWork, IGenericRepository<FuelType> fuelTypeRepository, IMapper mapper, CreateFuelTypeValidator createFuelTypeValidator, UpdateFuelTypeValidator updateFuelTypeValidator)
        {
            _unitOfWork = unitOfWork;
            _fuelTypeRepository = fuelTypeRepository;
            _mapper = mapper;
            _createFuelTypeValidator = createFuelTypeValidator;
            _updateFuelTypeValidator = updateFuelTypeValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public IEnumerable<FuelTypeDto> GetFuelTypes(SearchFuelTypeDto searchFuelType)
        {
            var orderBy = searchFuelType.OrderBy.Split(new[] { '-' })[0];
            var direction = searchFuelType.OrderBy?.Split(new[] { '-' })[1];

            var fuelTypes = _fuelTypeRepository.GetAll(searchFuelType.PageNumber, 
                                                       searchFuelType.PageSize,
                                                       f => f.Name.Contains(Strings.Trim(searchFuelType.FuelTypeName)),
                                                       q => q.OrderBy($"{orderBy} {direction}"));

            return _mapper.Map<IEnumerable<FuelTypeDto>>(fuelTypes);
        }

        public PagedList<FuelType> PagedListFuelTypes(SearchFuelTypeDto searchFuelType)
        {
            return _fuelTypeRepository.GetAll(searchFuelType.PageNumber, 
                                              searchFuelType.PageSize, 
                                              r => r.Name.Contains(Strings.Trim(searchFuelType.FuelTypeName)));
        }

        public FuelTypeDto GetFuelTypeById(int fuelTypeId)
        {
            var fuelType = _fuelTypeRepository.GetOne(fuelTypeId).EntityNotFoundCheck();

            return _mapper.Map<FuelTypeDto>(fuelType);
        }

        public FuelTypeDto CreateFuelType(CreateFuelTypeDto fuelTypeDto)
        {
            _createFuelTypeValidator.ValidateAndThrow(fuelTypeDto);

            var fuelTypeEntity = _mapper.Map<FuelType>(fuelTypeDto);
            _fuelTypeRepository.Create(fuelTypeEntity);
            _unitOfWork.Commit();

            var fuelTypeToReturn = _mapper.Map<FuelTypeDto>(fuelTypeEntity);
            return fuelTypeToReturn;
        }

        public void UpdateFuelTypePut(int fuelTypeId, UpdateFuelTypeDto fuelTypeDto)
        {
            var fuelType = _fuelTypeRepository.GetOne(fuelTypeId).EntityNotFoundCheck();

            fuelTypeDto.Id = fuelTypeId;

            _updateFuelTypeValidator.ValidateAndThrow(fuelTypeDto);
            _fuelTypeRepository.Update(fuelType);
            _mapper.Map(fuelTypeDto, fuelType);
            _unitOfWork.Commit();
        }

        public void UpdateFuelTypePatch(int fuelTypeId, JsonPatchDocument<UpdateFuelTypeDto> patchDocument)
        {
            var fuelType = _fuelTypeRepository.GetOne(fuelTypeId).EntityNotFoundCheck();

            var fuelTypeDto = _mapper.Map<UpdateFuelTypeDto>(fuelType);

            patchDocument.ApplyTo(fuelTypeDto);

            fuelTypeDto.Id = fuelTypeId;

            _updateFuelTypeValidator.ValidateAndThrow(fuelTypeDto);
            _fuelTypeRepository.Update(fuelType);
            _mapper.Map(fuelTypeDto, fuelType);
            _unitOfWork.Commit();
        }

        public void DeleteFuelType(int fuelTypeId)
        {
            _fuelTypeRepository.GetOne(fuelTypeId).EntityNotFoundCheck();

            _fuelTypeRepository.Delete(fuelTypeId);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}