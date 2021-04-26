using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.VisualBasic;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.Helpers;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Helpers;
using ProjectCars.Service.Validation;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;

namespace ProjectCars.Service
{
    public class ServiceRequestService : IServiceRequestService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<ServiceRequest> _serviceRequestRepository;
        private readonly IMapper _mapper;
        private readonly CreateServiceRequestValidator _createServiceRequestValidator;
        private readonly UpdateServiceRequestValidator _updateServiceRequestValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public ServiceRequestService(IUnitOfWork unitOfWork, IGenericRepository<ServiceRequest> serviceRequestRepository, IMapper mapper, CreateServiceRequestValidator createServiceRequestValidator, UpdateServiceRequestValidator updateServiceRequestValidator)
        {
            _unitOfWork = unitOfWork;
            _serviceRequestRepository = serviceRequestRepository;
            _mapper = mapper;
            _createServiceRequestValidator = createServiceRequestValidator;
            _updateServiceRequestValidator = updateServiceRequestValidator;
        }

        #endregion
        
        #region METHODS

        public IEnumerable<ServiceRequestDto> GetServiceRequests(SearchServiceRequestDto searchServiceRequest)
        {
            var orderBy = searchServiceRequest.OrderBy.Split(new[] { '-' })[0];
            var direction = searchServiceRequest.OrderBy?.Split(new[] { '-' })[1];

            var serviceRequests = _serviceRequestRepository.GetAll(searchServiceRequest.PageNumber, searchServiceRequest.PageSize,
                sr => sr.RepairEnd >= searchServiceRequest.DateRepairedFrom && sr.RepairEnd <= searchServiceRequest.DateRepairedTo,
                q => q.OrderBy($"{orderBy} {direction}"));

            return _mapper.Map<IEnumerable<ServiceRequestDto>>(serviceRequests);
        }

        public PagedList<ServiceRequest> PagedListServiceRequests(SearchServiceRequestDto searchServiceRequest)
        {
            return _serviceRequestRepository.GetAll(searchServiceRequest.PageNumber, 
                searchServiceRequest.PageSize, 
                sr => sr.RepairEnd >= searchServiceRequest.DateRepairedFrom && sr.RepairEnd <= searchServiceRequest.DateRepairedTo
                );
        }

        public ServiceRequestDto GetServiceRequestById(int serviceRequestId)
        {
            var serviceRequest = _serviceRequestRepository.GetOne(serviceRequestId).EntityNotFoundCheck();

            return _mapper.Map<ServiceRequestDto>(serviceRequest);
        }

        public ServiceRequestDto CreateServiceRequest(CreateServiceRequestDto serviceRequestDto)
        {
            _createServiceRequestValidator.ValidateAndThrow(serviceRequestDto);

            var serviceRequestEntity = _mapper.Map<ServiceRequest>(serviceRequestDto);
            _serviceRequestRepository.Create(serviceRequestEntity);
            _unitOfWork.Commit();

            var serviceRequestToReturn = _mapper.Map<ServiceRequestDto>(serviceRequestEntity);
            return serviceRequestToReturn;
        }

        public void UpdateServiceRequestPut(int serviceRequestId, UpdateServiceRequestDto serviceRequestDto)
        {
            var serviceRequest = _serviceRequestRepository.GetOne(serviceRequestId).EntityNotFoundCheck();

            _updateServiceRequestValidator.ValidateAndThrow(serviceRequestDto);
            _serviceRequestRepository.Update(serviceRequest);
            _mapper.Map(serviceRequestDto, serviceRequest);
            _unitOfWork.Commit();
        }

        public void UpdateServiceRequestPatch(int serviceRequestId, JsonPatchDocument<UpdateServiceRequestDto> patchDocument)
        {
            var serviceRequest = _serviceRequestRepository.GetOne(serviceRequestId).EntityNotFoundCheck();

            var serviceRequestDto = _mapper.Map<UpdateServiceRequestDto>(serviceRequest);

            patchDocument.ApplyTo(serviceRequestDto);

            _updateServiceRequestValidator.ValidateAndThrow(serviceRequestDto);
            _serviceRequestRepository.Update(serviceRequest);
            _mapper.Map(serviceRequestDto, serviceRequest);
            _unitOfWork.Commit();
        }

        public void DeleteServiceRequest(int serviceRequestId)
        {
            _serviceRequestRepository.GetOne(serviceRequestId).EntityNotFoundCheck();

            _serviceRequestRepository.Delete(serviceRequestId);
            _unitOfWork.Commit();
        } 

        #endregion
    }
}
