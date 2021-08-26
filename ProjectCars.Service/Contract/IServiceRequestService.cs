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
    public interface IServiceRequestService
    {
        /// <summary>
        /// Returns all Service Requests based on user filters
        /// </summary>
        /// <param name="searchServiceRequest"></param>
        /// <returns>Returns collection of ServiceRequest></returns>
        List<ServiceRequestDto> GetServiceRequests(SearchServiceRequestDto searchServiceRequest);

        /// <summary>
        /// Return pagination data for creating X-Pagination header
        /// </summary>
        /// <param name="searchServiceRequest"></param>
        /// <returns>Returns PagedList of roles</returns>
        PaginationData<ServiceRequest> PaginationData(SearchServiceRequestDto searchServiceRequest);

        /// <summary>
        /// Returns one Service Request
        /// </summary>
        /// <param name="serviceRequestId"></param>
        /// <returns>Returns one Service Request object</returns>
        ServiceRequestDto GetServiceRequestById(int serviceRequestId);

        /// <summary>
        /// Creates Service Request entity
        /// </summary>
        /// <param name="serviceRequestDto"></param>
        /// <returns>Created Service Request for Location header</returns>
        ServiceRequestDto CreateServiceRequest(CreateServiceRequestDto serviceRequestDto);

        /// <summary>
        /// Update Service Request using PUT method entity
        /// </summary>
        /// <param name="serviceRequestId"></param>
        /// <param name="serviceRequestDto"></param>
        void UpdateServiceRequestPut(int serviceRequestId, UpdateServiceRequestDto serviceRequestDto);

        /// <summary>
        /// Update Service Request using PATCH method entity
        /// </summary>
        /// <param name="serviceRequestId"></param>
        /// <param name="patchDocument"></param>
        void UpdateServiceRequestPatch(int serviceRequestId, JsonPatchDocument<UpdateServiceRequestDto> patchDocument);

        /// <summary>
        /// Delete Service Request
        /// </summary>
        /// <param name="serviceRequestId"></param>
        void DeleteServiceRequest(int serviceRequestId);
    }
}
