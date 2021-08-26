using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface IServiceRequestRepository : IGenericRepository<ServiceRequest>
    {
        /// <summary>
        /// Returns all service requests that match input filters
        /// </summary>
        /// <param name="searchServiceRequest"></param>
        /// <returns></returns>
        List<ServiceRequestDto> GetAll(SearchServiceRequestDto searchServiceRequest);

        /// <summary>
        /// Get one service request that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceRequestDto GetOne(int id);
    }
}