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
    public class CountryService : ICountryService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Country> _countryRepository;
        private readonly IMapper _mapper;
        private readonly CreateCountryValidator _createCountryValidator;
        private readonly UpdateCountryValidator _updateCountryValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CountryService(UpdateCountryValidator updateCountryValidator, CreateCountryValidator createCountryValidator, IMapper mapper, IGenericRepository<Country> countryRepository, IUnitOfWork unitOfWork)
        {
            _updateCountryValidator = updateCountryValidator;
            _createCountryValidator = createCountryValidator;
            _mapper = mapper;
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public IEnumerable<CountryDto> GetCountries(SearchCountryDto searchCountry)
        {
            var orderBy = searchCountry.OrderBy.Split(new[] { '-' })[0];
            var direction = searchCountry.OrderBy?.Split(new[] { '-' })[1];

            var countries = _countryRepository.GetAll(searchCountry.PageNumber, 
                                                      searchCountry.PageSize,
                                                      c => c.Name.Contains(Strings.Trim(searchCountry.CountryName)),
                                                      q => q.OrderBy($"{orderBy} {direction}"));

            return _mapper.Map<IEnumerable<CountryDto>>(countries);
        }

        public PagedList<Country> PagedListCountries(SearchCountryDto searchCountry)
        {
            return _countryRepository.GetAll(searchCountry.PageNumber, 
                                             searchCountry.PageSize, 
                                             r => r.Name.Contains(Strings.Trim(searchCountry.CountryName)));
        }

        public CountryDto GetCountryById(int countryId)
        {
            var country = _countryRepository.GetOne(countryId).EntityNotFoundCheck();

            return _mapper.Map<CountryDto>(country);
        }

        public CountryDto CreateCountry(CreateCountryDto countryDto)
        {
            _createCountryValidator.ValidateAndThrow(countryDto);

            var countryEntity = _mapper.Map<Country>(countryDto);
            _countryRepository.Create(countryEntity);
            _unitOfWork.Commit();

            var countryToReturn = _mapper.Map<CountryDto>(countryEntity);
            return countryToReturn;
        }

        public void UpdateCountryPut(int countryId, UpdateCountryDto countryDto)
        {
            var country = _countryRepository.GetOne(countryId).EntityNotFoundCheck();

            countryDto.Id = countryId;

            _updateCountryValidator.ValidateAndThrow(countryDto);
            _countryRepository.Update(country);
            _mapper.Map(countryDto, country);
            _unitOfWork.Commit();
        }

        public void UpdateCountryPatch(int countryId, JsonPatchDocument<UpdateCountryDto> patchDocument)
        {
            var country = _countryRepository.GetOne(countryId).EntityNotFoundCheck();

            var countryDto = _mapper.Map<UpdateCountryDto>(country);

            patchDocument.ApplyTo(countryDto);

            countryDto.Id = countryId;

            _updateCountryValidator.ValidateAndThrow(countryDto);
            _countryRepository.Update(country);
            _mapper.Map(countryDto, country);
            _unitOfWork.Commit();
        }

        public void DeleteCountry(int countryId)
        {
            _countryRepository.GetOne(countryId).EntityNotFoundCheck();

            _countryRepository.Delete(countryId);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}