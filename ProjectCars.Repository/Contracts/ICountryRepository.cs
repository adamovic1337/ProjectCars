using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        /// <summary>
        /// Returns all countries that match input filters
        /// </summary>
        /// <param name="searchCountry"></param>
        /// <returns></returns>
        List<CountryDto> GetAll(SearchCountryDto searchCountry);

        /// <summary>
        /// Get one country that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CountryDto GetOne(int id);
    }
}
