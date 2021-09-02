using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Helpers;
using System.Collections.Generic;

namespace ProjectCars.Service.Contract
{
    public interface IMaintenanceService
    {
        /// <summary>
        /// Returns all maintenance based on user filters
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carId"></param>
        /// <param name="searchMaintenance"></param>
        /// <returns></returns>
        List<MaintenanceDto> GetMaintenances(int userId, int carId, SearchMaintenanceDto searchMaintenance);

        /// <summary>
        /// Returns pagination data for creating X-Pagination header
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="carId"></param>
        /// <param name="searchMaintenance"></param>
        /// <returns></returns>
        PaginationData<Maintenance> PaginationData(int userId, int carId, SearchMaintenanceDto searchMaintenance);

        /// <summary>
        /// Returns all maintenance based on user filters
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="searchMaintenance"></param>
        /// <returns></returns>
        List<MaintenanceDto> GetMaintenances(int carServiceId, SearchMaintenanceDto searchMaintenance);

        /// <summary>
        /// Returns pagination data for creating X-Pagination header
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="searchMaintenance"></param>
        /// <returns></returns>
        PaginationData<Maintenance> PaginationData(int carServiceId, SearchMaintenanceDto searchMaintenance);

        /// <summary>
        /// Returns one Maintenance
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="maintenanceId"></param>
        /// <returns></returns>
        MaintenanceDto GetMaintenanceById(int carServiceId, int maintenanceId);

        /// <summary>
        /// Creates Maintenance entity
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="maintenanceDto"></param>
        /// <returns></returns>
        MaintenanceDto CreateMaintenance(int carServiceId, CreateMaintenanceDto maintenanceDto);

        /// <summary>
        /// Update Maintenance using PUT method entity
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="maintenanceId"></param>
        /// <param name="maintenanceDto"></param>
        void UpdateMaintenancePut(int carServiceId, int maintenanceId, UpdateMaintenanceDto maintenanceDto);

        /// <summary>
        /// Update Maintenance using PATCH method entity
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="maintenanceId"></param>
        /// <param name="patchDocument"></param>
        void UpdateMaintenancePatch(int carServiceId, int maintenanceId, JsonPatchDocument<UpdateMaintenanceDto> patchDocument);

        /// <summary>
        /// Delete Maintenance
        /// </summary>
        /// <param name="carServiceId"></param>
        /// <param name="maintenanceId"></param>
        void DeleteMaintenance(int carServiceId, int maintenanceId);
    }
}
