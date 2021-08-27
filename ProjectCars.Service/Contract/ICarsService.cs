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
    public interface ICarsService
    {
        /// <summary>
        /// Returns all cars based on user filters
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="searchCar"></param>
        /// <returns></returns>
        List<CarDto> GetCars(int userId, SearchCarDto searchCar);

        /// <summary>
        /// Returns pagination data for creating X-Pagination header
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="searchCar"></param>
        /// <returns></returns>
        PaginationData<Car> PaginationData(int userId, SearchCarDto searchCar);

        /// <summary>
        /// Returns one Car
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carId"></param>
        /// <returns></returns>
        CarDto GetCarById(int userId, int carId);

        /// <summary>
        /// Creates Car entity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carDto"></param>
        /// <returns></returns>
        CarDto CreateCar(int userId, CreateCarDto carDto);

        /// <summary>
        /// Update Car using PUT method entity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carId"></param>
        /// <param name="carDto"></param>
        void UpdateCarPut(int userId, int carId, UpdateCarDto carDto);

        /// <summary>
        /// Update Car using PATCH method entity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carId"></param>
        /// <param name="patchDocument"></param>
        void UpdateCarPatch(int userId, int carId, JsonPatchDocument<UpdateCarDto> patchDocument);

        /// <summary>
        /// Delete Car
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carId"></param>
        void DeleteCar(int userId, int carId);
    }
}