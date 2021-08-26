using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface ICarModelRepository : IGenericRepository<CarModel>
    {
        /// <summary>
        /// Returns all users that match input filters
        /// </summary>
        /// <param name="searchCarModel"></param>
        /// <returns></returns>
        List<CarModelDto> GetAll(SearchCarModelDto searchCarModel);

        /// <summary>
        /// Get one user that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CarModelDto GetOne(int id);
    }
}
