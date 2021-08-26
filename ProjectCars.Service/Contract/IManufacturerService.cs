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
    public interface IManufacturerService
    {
        /// <summary>
        /// Returns all Manufacturers based on user filters
        /// </summary>
        /// <param name="searchManufacturer"></param>
        /// <returns>Returns collection of Manufacturer></returns>
        List<ManufacturerDto> GetManufacturers(SearchManufacturerDto searchManufacturer);

        /// <summary>
        /// Return pagination data for creating X-Pagination header
        /// </summary>
        /// <param name="searchManufacturer"></param>
        /// <returns>Returns PagedList of Manufacturers</returns>
        PaginationData<Manufacturer> PaginationData(SearchManufacturerDto searchManufacturer);

        /// <summary>
        /// Returns one Manufacturer
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <returns>Returns one Manufacturer object</returns>
        ManufacturerDto GetManufacturerById(int manufacturerId);

        /// <summary>
        /// Creates Manufacturer entity
        /// </summary>
        /// <param name="manufacturerDto"></param>
        /// <returns>Created Manufacturer for Location header</returns>
        ManufacturerDto CreateManufacturer(CreateManufacturerDto manufacturerDto);

        /// <summary>
        /// Update Manufacturer using PUT method entity
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <param name="manufacturerDto"></param>
        void UpdateManufacturerPut(int manufacturerId, UpdateManufacturerDto manufacturerDto);

        /// <summary>
        /// Update Manufacturer using PATCH method entity
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <param name="patchDocument"></param>
        void UpdateManufacturerPatch(int manufacturerId, JsonPatchDocument<UpdateManufacturerDto> patchDocument);

        /// <summary>
        /// Delete Manufacturer
        /// </summary>
        /// <param name="manufacturerId"></param>
        void DeleteManufacturer(int manufacturerId);
    }
}
