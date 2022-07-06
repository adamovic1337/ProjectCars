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

namespace ProjectCars.Service
{
    public class CountryService : ICountryService
    {
        #region FIELDS

        
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly CreateCountryValidator _createCountryValidator;
        private readonly UpdateCountryValidator _updateCountryValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CountryService(UpdateCountryValidator updateCountryValidator, CreateCountryValidator createCountryValidator, IMapper mapper, ICountryRepository countryRepository)
        {
            _updateCountryValidator = updateCountryValidator;
            _createCountryValidator = createCountryValidator;
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<CountryDto> GetCountries(SearchCountryDto searchCountry)
        {
            return _countryRepository.GetAll(searchCountry);
        }

        public PaginationData<Country> PaginationData(SearchCountryDto searchCountry)
        {
            return _countryRepository.GetPaginationData(searchCountry, 
                                                        r => r.Name.Contains(searchCountry.CountryName.Trim()));
        }

        public CountryDto GetCountryById(int countryId)
        {
            return _countryRepository.GetOne(countryId).EntityNotFoundCheck();
        }

        public CountryDto CreateCountry(CreateCountryDto countryDto)
        {
            _createCountryValidator.ValidateAndThrow(countryDto);

            var countryEntity = _mapper.Map<Country>(countryDto);
            _countryRepository.Create(countryEntity);
            _countryRepository.Save();

            var countryToReturn = _mapper.Map<CountryDto>(countryEntity);
            return countryToReturn;
        }

        public void UpdateCountryPut(int countryId, UpdateCountryDto countryDto)
        {
            var country = _countryRepository.GetEntity(countryId).EntityNotFoundCheck();

            countryDto.Id = countryId;

            _updateCountryValidator.ValidateAndThrow(countryDto);
            _countryRepository.Update(country);
            _mapper.Map(countryDto, country);
            _countryRepository.Save();
        }

        public void UpdateCountryPatch(int countryId, JsonPatchDocument<UpdateCountryDto> patchDocument)
        {
            var country = _countryRepository.GetEntity(countryId).EntityNotFoundCheck();

            var countryDto = _mapper.Map<UpdateCountryDto>(country);

            patchDocument.ApplyTo(countryDto);

            countryDto.Id = countryId;

            _updateCountryValidator.ValidateAndThrow(countryDto);
            _countryRepository.Update(country);
            _mapper.Map(countryDto, country);
            _countryRepository.Save();
        }

        public void DeleteCountry(int countryId)
        {
            var country = _countryRepository.GetEntity(countryId).EntityNotFoundCheck();

            _countryRepository.Delete(country);
            _countryRepository.Save();
        }

        #endregion METHODS
    }
}