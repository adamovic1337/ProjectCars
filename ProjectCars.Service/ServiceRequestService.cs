using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.Helpers;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Helpers;
using ProjectCars.Service.Validation;
using System.Collections.Generic;

namespace ProjectCars.Service
{
    public class ServiceRequestService : IServiceRequestService
    {
        #region FIELDS

        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IMapper _mapper;
        private readonly CreateServiceRequestValidator _createServiceRequestValidator;
        private readonly UpdateServiceRequestValidator _updateServiceRequestValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public ServiceRequestService(IServiceRequestRepository serviceRequestRepository, IMapper mapper, CreateServiceRequestValidator createServiceRequestValidator, UpdateServiceRequestValidator updateServiceRequestValidator)
        {
            _serviceRequestRepository = serviceRequestRepository;
            _mapper = mapper;
            _createServiceRequestValidator = createServiceRequestValidator;
            _updateServiceRequestValidator = updateServiceRequestValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<ServiceRequestDto> GetServiceRequests(SearchServiceRequestDto searchServiceRequest)
        {
            return _serviceRequestRepository.GetAll(searchServiceRequest);
        }

        public PaginationData<ServiceRequest> PaginationData(SearchServiceRequestDto searchServiceRequest)
        {
            return _serviceRequestRepository.GetPaginationData(searchServiceRequest,
                                                               sr => sr.StatusId == searchServiceRequest.StatusId);
        }

        public ServiceRequestDto GetServiceRequestById(int serviceRequestId)
        {
            return _serviceRequestRepository.GetOne(serviceRequestId).EntityNotFoundCheck();
        }

        public ServiceRequestDto CreateServiceRequest(CreateServiceRequestDto serviceRequestDto)
        {
            _createServiceRequestValidator.ValidateAndThrow(serviceRequestDto);

            var serviceRequestEntity = _mapper.Map<ServiceRequest>(serviceRequestDto);
            _serviceRequestRepository.Create(serviceRequestEntity);
            _serviceRequestRepository.Save();

            var serviceRequestToReturn = _mapper.Map<ServiceRequestDto>(serviceRequestEntity);
            return serviceRequestToReturn;
        }

        public void UpdateServiceRequestPut(int serviceRequestId, UpdateServiceRequestDto serviceRequestDto)
        {
            var serviceRequest = _serviceRequestRepository.GetEntity(serviceRequestId).EntityNotFoundCheck();

            _updateServiceRequestValidator.ValidateAndThrow(serviceRequestDto);
            _serviceRequestRepository.Update(serviceRequest);
            _mapper.Map(serviceRequestDto, serviceRequest);
            _serviceRequestRepository.Save();
        }

        public void UpdateServiceRequestPatch(int serviceRequestId, JsonPatchDocument<UpdateServiceRequestDto> patchDocument)
        {
            var serviceRequest = _serviceRequestRepository.GetEntity(serviceRequestId).EntityNotFoundCheck();

            var serviceRequestDto = _mapper.Map<UpdateServiceRequestDto>(serviceRequest);

            patchDocument.ApplyTo(serviceRequestDto);

            _updateServiceRequestValidator.ValidateAndThrow(serviceRequestDto);
            _serviceRequestRepository.Update(serviceRequest);
            _mapper.Map(serviceRequestDto, serviceRequest);
            _serviceRequestRepository.Save();
        }

        public void DeleteServiceRequest(int serviceRequestId)
        {
            var serviceRequest = _serviceRequestRepository.GetEntity(serviceRequestId).EntityNotFoundCheck();

            _serviceRequestRepository.Delete(serviceRequest);
            _serviceRequestRepository.Save();
        }

        #endregion METHODS
    }
}