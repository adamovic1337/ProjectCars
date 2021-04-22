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
    public interface ICarModelService
    {
        /// <summary>
        /// Returns all Car Models based on user filters
        /// </summary>
        /// <param name="searchCarModel"></param>
        /// <returns>Returns collection of Car Model></returns>
        IEnumerable<CarModelDto> GetCarModels(SearchCarModelDto searchCarModel);

        /// <summary>
        /// Return PagedList for creating X-Pagination header
        /// </summary>
        /// <param name="searchCarModel"></param>
        /// <returns>Returns PagedList of roles</returns>
        PagedList<CarModel> PagedListCarModels(SearchCarModelDto searchCarModel);

        /// <summary>
        /// Returns one Car Model
        /// </summary>
        /// <param name="carModelId"></param>
        /// <returns>Returns one Car Model object</returns>
        CarModelDto GetCarModelById(int carModelId);

        /// <summary>
        /// Creates Car Model entity
        /// </summary>
        /// <param name="carModelDto"></param>
        /// <returns>Created Role for Location header</returns>
        CarModelDto CreateCarModel(CreateCarModelDto carModelDto);

        /// <summary>
        /// Update Car Model using PUT method entity
        /// </summary>
        /// <param name="carModelId"></param>
        /// <param name="carModelDto"></param>
        void UpdateCarModelPut(int carModelId, UpdateCarModelDto carModelDto);

        /// <summary>
        /// Update Car Model using PATCH method entity
        /// </summary>
        /// <param name="carModelId"></param>
        /// <param name="patchDocument"></param>
        void UpdateCarModelPatch(int carModelId, JsonPatchDocument<UpdateCarModelDto> patchDocument);

        /// <summary>
        /// Delete Car Model
        /// </summary>
        /// <param name="carModelId"></param>
        void DeleteCarModel(int carModelId);
    }
}
