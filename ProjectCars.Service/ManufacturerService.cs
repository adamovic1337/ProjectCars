using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
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
using System.Linq.Dynamic.Core;

namespace ProjectCars.Service
{
    public class ManufacturerService : IManufacturerService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;
        private readonly CreateManufacturerValidator _createManufacturerValidator;
        private readonly UpdateManufacturerValidator _updateManufacturerValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public ManufacturerService(IUnitOfWork unitOfWork, IManufacturerRepository manufacturerRepository, IMapper mapper, CreateManufacturerValidator createManufacturerValidator, UpdateManufacturerValidator updateManufacturerValidator)
        {
            _unitOfWork = unitOfWork;
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
            _createManufacturerValidator = createManufacturerValidator;
            _updateManufacturerValidator = updateManufacturerValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<ManufacturerDto> GetManufacturers(SearchManufacturerDto searchManufacturer)
        {
            return _manufacturerRepository.GetAll(searchManufacturer);
        }

        public PaginationData<Manufacturer> PaginationData(SearchManufacturerDto searchManufacturer)
        {
            return _manufacturerRepository.GetPaginationData(searchManufacturer, 
                                                             r => r.Name.Contains(searchManufacturer.ManufacturerName.Trim()));
        }

        public ManufacturerDto GetManufacturerById(int manufacturerId)
        {
            return _manufacturerRepository.GetOne(manufacturerId).EntityNotFoundCheck();
        }

        public ManufacturerDto CreateManufacturer(CreateManufacturerDto manufacturerDto)
        {
            _createManufacturerValidator.ValidateAndThrow(manufacturerDto);

            var manufacturerEntity = _mapper.Map<Manufacturer>(manufacturerDto);
            _manufacturerRepository.Create(manufacturerEntity);
            _unitOfWork.Commit();

            var manufacturerToReturn = _mapper.Map<ManufacturerDto>(manufacturerEntity);

            return manufacturerToReturn;
        }

        public void UpdateManufacturerPut(int manufacturerId, UpdateManufacturerDto manufacturerDto)
        {
            var manufacturer = _manufacturerRepository.GetEntity(manufacturerId).EntityNotFoundCheck();

            manufacturerDto.Id = manufacturerId;

            _updateManufacturerValidator.ValidateAndThrow(manufacturerDto);
            _manufacturerRepository.Update(manufacturer);
            _mapper.Map(manufacturerDto, manufacturer);
            _unitOfWork.Commit();
        }

        public void UpdateManufacturerPatch(int manufacturerId, JsonPatchDocument<UpdateManufacturerDto> patchDocument)
        {
            var manufacturer = _manufacturerRepository.GetEntity(manufacturerId).EntityNotFoundCheck();

            var manufacturerDto = _mapper.Map<UpdateManufacturerDto>(manufacturer);

            patchDocument.ApplyTo(manufacturerDto);

            manufacturerDto.Id = manufacturerId;

            _updateManufacturerValidator.ValidateAndThrow(manufacturerDto);
            _manufacturerRepository.Update(manufacturer);
            _mapper.Map(manufacturerDto, manufacturer);
            _unitOfWork.Commit();
        }

        public void DeleteManufacturer(int manufacturerId)
        {
            var manufacturer = _manufacturerRepository.GetEntity(manufacturerId).EntityNotFoundCheck();

            _manufacturerRepository.Delete(manufacturer);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}