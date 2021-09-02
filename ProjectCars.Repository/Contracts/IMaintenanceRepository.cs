using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.Helpers;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface IMaintenanceRepository : IGenericRepository<Maintenance>
    {
        /// <summary>
        /// Returns all maintenances that match input filters
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carId"></param>
        /// <param name="searchMaintenance"></param>
        /// <returns></returns>
        List<MaintenanceDto> GetAll(int userId, int carId, SearchMaintenanceDto searchMaintenance);

        /// <summary>
        /// Returns all maintenances that match input filters
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="searchMaintenance"></param>
        /// <returns></returns>
        List<MaintenanceDto> GetAll(int carServiceId, SearchMaintenanceDto searchMaintenance);

        /// <summary>
        /// Get all pagination data
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carId"></param>
        /// <param name="searchMaintenance"></param>
        /// <returns></returns>
        PaginationData<Maintenance> GetPaginationData(int userId, int carId, SearchMaintenanceDto searchMaintenance);

        /// <summary>
        /// Get all pagination data
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="searchMaintenance"></param>
        /// <returns></returns>
        PaginationData<Maintenance> GetPaginationData(int carServiceId, SearchMaintenanceDto searchMaintenance);

        /// <summary>
        /// Get one car that matches input filter
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="maintenanceId"></param>
        /// <returns></returns>
        MaintenanceDto GetOne(int carServiceId, int maintenanceId);

        /// <summary>
        /// Get one record by id for update
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="maintenanceId"></param>
        /// <returns></returns>
        Maintenance GetEntity(int carServiceId, int maintenanceId);
    }
}
