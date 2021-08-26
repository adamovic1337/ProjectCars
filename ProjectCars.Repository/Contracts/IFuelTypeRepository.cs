using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;


namespace ProjectCars.Repository.Contracts
{
    public interface IFuelTypeRepository : IGenericRepository<FuelType>
    {
        /// <summary>
        /// Returns all fuel types that match input filters
        /// </summary>
        /// <param name="searchFuelType"></param>
        /// <returns></returns>
        List<FuelTypeDto> GetAll(SearchFuelTypeDto searchFuelType);

        /// <summary>
        /// Get one fuel type that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FuelTypeDto GetOne(int id);
    }
}
