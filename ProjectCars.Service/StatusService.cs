using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.Helpers;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Helpers;
using ProjectCars.Service.Validation;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;

namespace ProjectCars.Service
{
    public class StatusService : IStatusService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;
        private readonly CreateStatusValidator _createStatusValidator;
        private readonly UpdateStatusValidator _updateStatusValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public StatusService(IUnitOfWork unitOfWork, IStatusRepository statusRepository, IMapper mapper, CreateStatusValidator createStatusValidator, UpdateStatusValidator updateStatusValidator)
        {
            _unitOfWork = unitOfWork;
            _statusRepository = statusRepository;
            _mapper = mapper;
            _createStatusValidator = createStatusValidator;
            _updateStatusValidator = updateStatusValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<StatusDto> GetStatus(SearchStatusDto searchStatus)
        {
            return _statusRepository.GetAll(searchStatus);
        }

        public PaginationData<Status> PaginationData(SearchStatusDto searchStatus)
        {
            return _statusRepository.GetPaginationData(searchStatus,
                                                       r => r.Name.Contains(searchStatus.StatusName.Trim()));
        }

        public StatusDto GetStatusById(int statusId)
        {
            return _statusRepository.GetOne(statusId).EntityNotFoundCheck();
        }

        public StatusDto CreateStatus(CreateStatusDto statusDto)
        {
            _createStatusValidator.ValidateAndThrow(statusDto);

            var statusEntity = _mapper.Map<Status>(statusDto);
            _statusRepository.Create(statusEntity);
            _unitOfWork.Commit();

            var statusToReturn = _mapper.Map<StatusDto>(statusEntity);
            return statusToReturn;
        }

        public void UpdateStatusPut(int statusId, UpdateStatusDto statusDto)
        {
            var status = _statusRepository.GetEntity(statusId).EntityNotFoundCheck();

            statusDto.Id = statusId;

            _updateStatusValidator.ValidateAndThrow(statusDto);
            _statusRepository.Update(status);
            _mapper.Map(statusDto, status);
            _unitOfWork.Commit();
        }

        public void UpdateStatusPatch(int statusId, JsonPatchDocument<UpdateStatusDto> patchDocument)
        {
            var status = _statusRepository.GetEntity(statusId).EntityNotFoundCheck();

            var statusDto = _mapper.Map<UpdateStatusDto>(status);

            patchDocument.ApplyTo(statusDto);

            statusDto.Id = statusId;

            _updateStatusValidator.ValidateAndThrow(statusDto);
            _statusRepository.Update(status);
            _mapper.Map(statusDto, status);
            _unitOfWork.Commit();
        }

        public void DeleteStatus(int statusId)
        {
            var status = _statusRepository.GetEntity(statusId).EntityNotFoundCheck();

            _statusRepository.Delete(status);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}