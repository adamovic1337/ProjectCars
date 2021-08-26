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
    public interface ICarServiceService
    {
        /// <summary>
        /// Returns all Car Services based on user filters
        /// </summary>
        /// <param name="searchCarService"></param>
        /// <returns>Returns collection of Car Service></returns>
        List<CarServiceDto> GetCarServices(SearchCarServiceDto searchCarService);

        /// <summary>
        /// Return Pagination Data for creating X-Pagination header
        /// </summary>
        /// <param name="searchCarService"></param>
        /// <returns>Returns PagedList of Car Service</returns>
        PaginationData<CarService> PaginationData(SearchCarServiceDto searchCarService);

        /// <summary>
        /// Returns one Car Service
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <returns>Returns one Car Service object</returns>
        CarServiceDto GetCarServiceById(int carServiceId);

        /// <summary>
        /// Creates Car Service entity
        /// </summary>
        /// <param name="carServiceDto"></param>
        /// <returns>Created Car Service for Location header</returns>
        CarServiceDto CreateCarService(CreateCarServiceDto carServiceDto);

        /// <summary>
        /// Update Car Service using PUT method entity
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="carServiceDto"></param>
        void UpdateCarServicePut(int carServiceId, UpdateCarServiceDto carServiceDto);

        /// <summary>
        /// Update CarService using PATCH method entity
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="patchDocument"></param>
        void UpdateCarServicePatch(int carServiceId, JsonPatchDocument<UpdateCarServiceDto> patchDocument);

        /// <summary>
        /// Delete Car Service
        /// </summary>
        /// <param name="carServiceId"></param>
        void DeleteCarService(int carServiceId);
    }
}