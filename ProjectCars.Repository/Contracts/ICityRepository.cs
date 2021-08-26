using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface ICityRepository : IGenericRepository<City>
    {
        /// <summary>
        /// Returns all cities that match input filters
        /// </summary>
        /// <param name="searchCity"></param>
        /// <returns></returns>
        List<CityDto> GetAll(SearchCityDto searchCity);

        /// <summary>
        /// Get one city that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CityDto GetOne(int id);
    }
}
