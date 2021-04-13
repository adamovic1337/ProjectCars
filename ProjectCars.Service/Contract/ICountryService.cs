using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Helpers;
using System.Collections.Generic;

namespace ProjectCars.Service.Contract
{
    public interface ICountryService
    {
        /// <summary>
        /// Returns all Countries based on user filters
        /// </summary>
        /// <param name="searchCountry"></param>
        /// <returns>Returns collection of Countries></returns>
        IEnumerable<CountryDto> GetCountries(SearchCountryDto searchCountry);

        /// <summary>
        /// Return PagedList for creating X-Pagination header
        /// </summary>
        /// <param name="searchCountry"></param>
        /// <returns>Returns PagedList of Countries</returns>
        PagedList<Country> PagedListCountries(SearchCountryDto searchCountry);

        /// <summary>
        /// Returns one Country
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>Returns one Country object</returns>
        CountryDto GetCountryById(int countryId);

        /// <summary>
        /// Creates Country entity
        /// </summary>
        /// <param name="countryDto"></param>
        /// <returns>Created Country for Location header</returns>
        CountryDto CreateCountry(CreateCountryDto countryDto);

        /// <summary>
        /// Update Country using PUT method entity
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="countryDto"></param>
        void UpdateCountryPut(int countryId, UpdateCountryDto countryDto);

        /// <summary>
        /// Update Country using PATCH method entity
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="patchDocument"></param>
        void UpdateCountryPatch(int countryId, JsonPatchDocument<UpdateCountryDto> patchDocument);

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="countryId"></param>
        void DeleteCountry(int countryId);
    }
}