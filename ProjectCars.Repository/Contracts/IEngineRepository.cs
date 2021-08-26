using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface IEngineRepository : IGenericRepository<Engine>
    {
        /// <summary>
        /// Returns all engines that match input filters
        /// </summary>
        /// <param name="searchEngine"></param>
        /// <returns></returns>
        List<EngineDto> GetAll(SearchEngineDto searchEngine);

        /// <summary>
        /// Get one user that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EngineDto GetOne(int id);
    }
}
