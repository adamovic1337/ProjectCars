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
    public class ManufacturerService : IManufacturerService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Manufacturer> _manufacturerRepository;
        private readonly IMapper _mapper;
        private readonly CreateManufacturerValidator _createManufacturerValidator;
        private readonly UpdateManufacturerValidator _updateManufacturerValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public ManufacturerService(IUnitOfWork unitOfWork, IGenericRepository<Manufacturer> manufacturerRepository, IMapper mapper, CreateManufacturerValidator createManufacturerValidator, UpdateManufacturerValidator updateManufacturerValidator)
        {
            _unitOfWork = unitOfWork;
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
            _createManufacturerValidator = createManufacturerValidator;
            _updateManufacturerValidator = updateManufacturerValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public IEnumerable<ManufacturerDto> GetManufacturers(SearchManufacturerDto searchManufacturer)
        {
            var orderBy = searchManufacturer.OrderBy.Split(new[] { '-' })[0];
            var direction = searchManufacturer.OrderBy?.Split(new[] { '-' })[1];

            var manufacturers = _manufacturerRepository.GetAll(searchManufacturer.PageNumber, searchManufacturer.PageSize,
                r => r.Name.Contains(Strings.Trim(searchManufacturer.ManufacturerName)),
                q => q.OrderBy($"{orderBy} {direction}"));

            return _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers);
        }

        public PagedList<Manufacturer> PagedListManufacturers(SearchManufacturerDto searchManufacturer)
        {
            return _manufacturerRepository.GetAll(searchManufacturer.PageNumber, searchManufacturer.PageSize, r => r.Name.Contains(Strings.Trim(searchManufacturer.ManufacturerName)));
        }

        public ManufacturerDto GetManufacturerById(int manufacturerId)
        {
            var manufacturer = _manufacturerRepository.GetOne(manufacturerId).EntityNotFoundCheck();

            return _mapper.Map<ManufacturerDto>(manufacturer);
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
            var manufacturer = _manufacturerRepository.GetOne(manufacturerId).EntityNotFoundCheck();

            _updateManufacturerValidator.ValidateAndThrow(manufacturerDto);
            _manufacturerRepository.Update(manufacturer);
            _mapper.Map(manufacturerDto, manufacturer);
            _unitOfWork.Commit();
        }

        public void UpdateManufacturerPatch(int manufacturerId, JsonPatchDocument<UpdateManufacturerDto> patchDocument)
        {
            var manufacturer = _manufacturerRepository.GetOne(manufacturerId).EntityNotFoundCheck();

            var manufacturerDto = _mapper.Map<UpdateManufacturerDto>(manufacturer);

            patchDocument.ApplyTo(manufacturerDto);

            _updateManufacturerValidator.ValidateAndThrow(manufacturerDto);
            _manufacturerRepository.Update(manufacturer);
            _mapper.Map(manufacturerDto, manufacturer);
            _unitOfWork.Commit();
        }

        public void DeleteManufacturer(int manufacturerId)
        {
            _manufacturerRepository.GetOne(manufacturerId).EntityNotFoundCheck();

            _manufacturerRepository.Delete(manufacturerId);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}