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
    public interface IStatusService
    {
        /// <summary>
        /// Returns Status based on user filters
        /// </summary>
        /// <param name="searchStatus"></param>
        /// <returns>Returns collection of Status></returns>
        IEnumerable<StatusDto> GetStatus(SearchStatusDto searchStatus);

        /// <summary>
        /// Return PagedList for creating X-Pagination header
        /// </summary>
        /// <param name="searchStatus"></param>
        /// <returns>Returns PagedList of Status</returns>
        PagedList<Status> PagedListStatus(SearchStatusDto searchStatus);

        /// <summary>
        /// Returns one Status
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns>Returns one Status object</returns>
        StatusDto GetStatusById(int statusId);

        /// <summary>
        /// Creates Status entity
        /// </summary>
        /// <param name="statusDto"></param>
        /// <returns>Created Role for Location header</returns>
        StatusDto CreateStatus(CreateStatusDto statusDto);

        /// <summary>
        /// Update Status using PUT method entity
        /// </summary>
        /// <param name="statusId"></param>
        /// <param name="statusDto"></param>
        void UpdateStatusPut(int statusId, UpdateStatusDto statusDto);

        /// <summary>
        /// Update Status using PATCH method entity
        /// </summary>
        /// <param name="statusId"></param>
        /// <param name="patchDocument"></param>
        void UpdateStatusPatch(int statusId, JsonPatchDocument<UpdateStatusDto> patchDocument);

        /// <summary>
        /// Delete Status
        /// </summary>
        /// <param name="statusId"></param>
        void DeleteStatus(int statusId);
    }
}
