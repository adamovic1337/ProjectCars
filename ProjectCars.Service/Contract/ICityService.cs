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
    public interface ICityService
    {
        /// <summary>
        /// Returns all Cities based on user filters
        /// </summary>
        /// <param name="searchCity"></param>
        /// <returns>Returns collection of Countries></returns>
        IEnumerable<CityDto> GetCountries(SearchCityDto searchCity);

        /// <summary>
        /// Return PagedList for creating X-Pagination header
        /// </summary>
        /// <param name="searchCity"></param>
        /// <returns>Returns PagedList of Cities</returns>
        PagedList<City> PagedListCities(SearchCityDto searchCity);

        /// <summary>
        /// Returns one Country
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns>Returns one City object</returns>
        CityDto GetCityById(int cityId);

        /// <summary>
        /// Creates City entity
        /// </summary>
        /// <param name="cityDto"></param>
        /// <returns>Created City for Location header</returns>
        CityDto CreateCity(CreateCityDto cityDto);

        /// <summary>
        /// Update City using PUT method entity
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="cityDto"></param>
        void UpdateCityPut(int cityId, UpdateCityDto cityDto);

        /// <summary>
        /// Update City using PATCH method entity
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="patchDocument"></param>
        void UpdateCityPatch(int cityId, JsonPatchDocument<UpdateCityDto> patchDocument);

        /// <summary>
        /// Delete City
        /// </summary>
        /// <param name="cityId"></param>
        void DeleteCity(int cityId);
    }
}