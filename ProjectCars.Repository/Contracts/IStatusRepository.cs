using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface IStatusRepository : IGenericRepository<Status>
    {
        /// <summary>
        /// Returns status that match input filters
        /// </summary>
        /// <param name="searchStatus"></param>
        /// <returns></returns>
        List<StatusDto> GetAll(SearchStatusDto searchStatus);

        /// <summary>
        /// get one status that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StatusDto GetOne(int id);
    }
}