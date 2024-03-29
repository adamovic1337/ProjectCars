﻿using AutoMapper;
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
    public class CityService : ICityService
    {
        #region FIELDS

        
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly CreateCityValidator _createCityValidator;
        private readonly UpdateCityValidator _updateCityValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CityService( ICityRepository cityRepository, IMapper mapper, CreateCityValidator createCityValidator, UpdateCityValidator updateCityValidator)
        {
            
            _cityRepository = cityRepository;
            _mapper = mapper;
            _createCityValidator = createCityValidator;
            _updateCityValidator = updateCityValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<CityDto> GetCities(SearchCityDto searchCity)
        {
            return _cityRepository.GetAll(searchCity);
        }

        public PaginationData<City> PaginationData(SearchCityDto searchCity)
        {
            return _cityRepository.GetPaginationData(searchCity, 
                                                     r => r.Name.Contains(searchCity.CityName.Trim()));
        }

        public CityDto GetCityById(int cityId)
        {
            return _cityRepository.GetOne(cityId).EntityNotFoundCheck();
        }

        public CityDto CreateCity(CreateCityDto cityDto)
        {
            _createCityValidator.ValidateAndThrow(cityDto);

            var cityEntity = _mapper.Map<City>(cityDto);
            _cityRepository.Create(cityEntity);
            _cityRepository.Save();

            var cityToReturn = _mapper.Map<CityDto>(cityEntity);
            return cityToReturn;
        }

        public void UpdateCityPut(int cityId, UpdateCityDto cityDto)
        {
            var city = _cityRepository.GetEntity(cityId).EntityNotFoundCheck();

            cityDto.Id = cityId;

            _updateCityValidator.ValidateAndThrow(cityDto);
            _cityRepository.Update(city);
            _mapper.Map(cityDto, city);
            _cityRepository.Save();
        }

        public void UpdateCityPatch(int cityId, JsonPatchDocument<UpdateCityDto> patchDocument)
        {
            var city = _cityRepository.GetEntity(cityId).EntityNotFoundCheck();

            var cityDto = _mapper.Map<UpdateCityDto>(city);

            patchDocument.ApplyTo(cityDto);

            cityDto.Id = cityId;

            _updateCityValidator.ValidateAndThrow(cityDto);
            _cityRepository.Update(city);
            _mapper.Map(cityDto, city);
            _cityRepository.Save();
        }

        public void DeleteCity(int cityId)
        {
            var city = _cityRepository.GetEntity(cityId).EntityNotFoundCheck();

            _cityRepository.Delete(city);
            _cityRepository.Save();
        }

        #endregion METHODS
    }
}