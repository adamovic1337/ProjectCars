using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface IManufacturerRepository : IGenericRepository<Manufacturer>
    {
        /// <summary>
        /// Returns all manufacturers that match input filters
        /// </summary>
        /// <param name="searchManufacturer"></param>
        /// <returns></returns>
        List<ManufacturerDto> GetAll(SearchManufacturerDto searchManufacturer);

        /// <summary>
        /// Get one manufacturer that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ManufacturerDto GetOne(int id);
    }
}