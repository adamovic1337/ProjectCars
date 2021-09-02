using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.Helpers;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        /// <summary>
        /// Returns all cars that match input filters
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="searchCar"></param>
        /// <returns></returns>
        List<CarDto> GetAll(int userId, SearchCarDto searchCar);

        /// <summary>
        /// Get all pagination data
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="searchCar"></param>
        /// <returns></returns>
        PaginationData<Car> GetPaginationData(int userId, SearchCarDto searchCar);

        /// <summary>
        /// Get one car that matches input filter
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carId"></param>
        /// <returns></returns>
        CarDto GetOne(int userId, int carId);

        /// <summary>
        /// Get one record by id for update
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carId"></param>
        /// <returns></returns>
        Car GetEntity(int userId, int carId);
    }
}