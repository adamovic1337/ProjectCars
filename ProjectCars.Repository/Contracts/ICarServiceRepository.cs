using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface ICarServiceRepository : IGenericRepository<CarService>
    {
        /// <summary>
        /// Returns all car services that match input filters
        /// </summary>
        /// <param name="searchCarService"></param>
        /// <returns></returns>
        List<CarServiceDto> GetAll(SearchCarServiceDto searchCarService);

        /// <summary>
        /// Get one car service that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CarServiceDto GetOne(int id);
    }
}
