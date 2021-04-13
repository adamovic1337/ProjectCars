using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.Helpers;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Validation;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using FluentValidation;
using Microsoft.VisualBasic;
using ProjectCars.Service.Helpers;

namespace ProjectCars.Service
{
    public class CityService : ICityService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IMapper _mapper;
        private readonly CreateCityValidator _createCityValidator;
        private readonly UpdateCityValidator _updateCityValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CityService(IUnitOfWork unitOfWork, IGenericRepository<City> cityRepository, IMapper mapper, CreateCityValidator createCountryValidator, UpdateCityValidator updateCountryValidator)
        {
            _unitOfWork = unitOfWork;
            _cityRepository = cityRepository;
            _mapper = mapper;
            _createCityValidator = createCountryValidator;
            _updateCityValidator = updateCountryValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public IEnumerable<CityDto> GetCountries(SearchCityDto searchCity)
        {
            var orderBy = searchCity.OrderBy.Split(new[] { '-' })[0];
            var direction = searchCity.OrderBy?.Split(new[] { '-' })[1];

            var cities = _cityRepository.GetAll(searchCity.PageNumber, searchCity.PageSize,
                c => c.Name.Contains(Strings.Trim(searchCity.CityName)),
                q => q.OrderBy($"{orderBy} {direction}"));

            return _mapper.Map<IEnumerable<CityDto>>(cities);
        }

        public PagedList<City> PagedListCities(SearchCityDto searchCity)
        {
            return _cityRepository.GetAll(searchCity.PageNumber, searchCity.PageSize, r => r.Name.Contains(Strings.Trim(searchCity.CityName)));
        }

        public CityDto GetCityById(int cityId)
        {
            var city = _cityRepository.GetOne(cityId).EntityNotFoundCheck();

            return _mapper.Map<CityDto>(city);
        }

        public CityDto CreateCity(CreateCityDto cityDto)
        {
            _createCityValidator.ValidateAndThrow(cityDto);

            var cityEntity = _mapper.Map<City>(cityDto);
            _cityRepository.Create(cityEntity);
            _unitOfWork.Commit();

            var cityToReturn = _mapper.Map<CityDto>(cityEntity);
            return cityToReturn;
        }

        public void UpdateCityPut(int cityId, UpdateCityDto cityDto)
        {
            var city = _cityRepository.GetOne(cityId).EntityNotFoundCheck();

            _updateCityValidator.ValidateAndThrow(cityDto);
            _cityRepository.Update(city);
            _mapper.Map(cityDto, city);
            _unitOfWork.Commit();
        }

        public void UpdateCityPatch(int cityId, JsonPatchDocument<UpdateCityDto> patchDocument)
        {
            var city = _cityRepository.GetOne(cityId).EntityNotFoundCheck();

            var cityDto = _mapper.Map<UpdateCityDto>(city);

            patchDocument.ApplyTo(cityDto);

            _updateCityValidator.ValidateAndThrow(cityDto);
            _cityRepository.Update(city);
            _mapper.Map(cityDto, city);
            _unitOfWork.Commit();
        }

        public void DeleteCity(int cityId)
        {
            _cityRepository.GetOne(cityId).EntityNotFoundCheck();

            _cityRepository.Delete(cityId);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}