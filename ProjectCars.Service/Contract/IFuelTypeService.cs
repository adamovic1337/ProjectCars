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
    public interface IFuelTypeService
    {
        /// <summary>
        /// Returns all FuelTypes based on user filters
        /// </summary>
        /// <param name="searchFuelType"></param>
        /// <returns>Returns collection of FuelTypes></returns>
        IEnumerable<FuelTypeDto> GetFuelTypes(SearchFuelTypeDto searchFuelType);

        /// <summary>
        /// Return PagedList for creating X-Pagination header
        /// </summary>
        /// <param name="searchFuelType"></param>
        /// <returns>Returns PagedList of FuelTypes</returns>
        PagedList<FuelType> PagedListRoles(SearchFuelTypeDto searchFuelType);

        /// <summary>
        /// Returns one FuelType
        /// </summary>
        /// <param name="fuelTypeId"></param>
        /// <returns>Returns one FuelType object</returns>
        FuelTypeDto GetFuelTypeById(int fuelTypeId);

        /// <summary>
        /// Creates FuelType entity
        /// </summary>
        /// <param name="fuelTypeDto"></param>
        /// <returns>Created FuelType for Location header</returns>
        FuelTypeDto CreateFuelType(CreateFuelTypeDto fuelTypeDto);

        /// <summary>
        /// Update FuelType using PUT method entity
        /// </summary>
        /// <param name="fuelTypeId"></param>
        /// <param name="fuelTypeDto"></param>
        void UpdateFuelTypePut(int fuelTypeId, UpdateFuelTypeDto fuelTypeDto);

        /// <summary>
        /// Update FuelType using PATCH method entity
        /// </summary>
        /// <param name="fuelTypeId"></param>
        /// <param name="patchDocument"></param>
        void UpdateFuelTypePatch(int fuelTypeId, JsonPatchDocument<UpdateFuelTypeDto> patchDocument);

        /// <summary>
        /// Delete FuelType
        /// </summary>
        /// <param name="fuelTypeId"></param>
        void DeleteFuelType(int fuelTypeId);
    }
}
