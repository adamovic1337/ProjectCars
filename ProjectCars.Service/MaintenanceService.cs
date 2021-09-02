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

namespace ProjectCars.Service
{
    public class MaintenanceService : IMaintenanceService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaintenanceRepository _maintenanceRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICarServiceRepository _carServiceRepository;
        private readonly IMapper _mapper;
        private readonly CreateMaintenanceValidator _createMaintenanceValidator;
        private readonly UpdateMaintenanceValidator _updateMaintenanceValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public MaintenanceService(IUnitOfWork unitOfWork, IMaintenanceRepository maintenanceRepository, IUserRepository userRepository, ICarServiceRepository carServiceRepository, IMapper mapper, UpdateMaintenanceValidator updateMaintenanceValidator, CreateMaintenanceValidator createMaintenanceValidator)
        {
            _unitOfWork = unitOfWork;
            _maintenanceRepository = maintenanceRepository;
            _userRepository = userRepository;
            _carServiceRepository = carServiceRepository;
            _mapper = mapper;
            _updateMaintenanceValidator = updateMaintenanceValidator;
            _createMaintenanceValidator = createMaintenanceValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<MaintenanceDto> GetMaintenances(int userId, int carId, SearchMaintenanceDto searchMaintenance)
        {
            _ = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            return _maintenanceRepository.GetAll(userId, carId, searchMaintenance).EntityNotFoundCheck();
        }

        public PaginationData<Maintenance> PaginationData(int userId, int carId, SearchMaintenanceDto searchMaintenance)
        {
            _ = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            return _maintenanceRepository.GetPaginationData(userId, carId, searchMaintenance);
        }

        public List<MaintenanceDto> GetMaintenances(int carServiceId, SearchMaintenanceDto searchMaintenance)
        {
            _ = _carServiceRepository.GetEntity(carServiceId).EntityNotFoundCheck();

            return _maintenanceRepository.GetAll(carServiceId, searchMaintenance).EntityNotFoundCheck();
        }        

        public PaginationData<Maintenance> PaginationData(int carServiceId, SearchMaintenanceDto searchMaintenance)
        {
            _ = _carServiceRepository.GetEntity(carServiceId).EntityNotFoundCheck();

            return _maintenanceRepository.GetPaginationData(carServiceId, searchMaintenance);
        }

        public MaintenanceDto GetMaintenanceById(int carServiceId, int maintenanceId)
        {
            _ = _carServiceRepository.GetEntity(carServiceId).EntityNotFoundCheck();

            return _maintenanceRepository.GetOne(carServiceId, maintenanceId).EntityNotFoundCheck();
        }

        public MaintenanceDto CreateMaintenance(int carServiceId, CreateMaintenanceDto maintenanceDto)
        {
            _createMaintenanceValidator.ValidateAndThrow(maintenanceDto);

            _ = _carServiceRepository.GetEntity(carServiceId).EntityNotFoundCheck();

            var maintenanceEntity = _mapper.Map<Maintenance>(maintenanceDto);
            maintenanceEntity.CarServiceId = carServiceId;

            _maintenanceRepository.Create(maintenanceEntity);
            _unitOfWork.Commit();

            var maintenanceToReturn = _maintenanceRepository.GetOne(carServiceId, maintenanceEntity.Id);

            return maintenanceToReturn;
        }    
               
        public void UpdateMaintenancePut(int carServiceId, int maintenanceId, UpdateMaintenanceDto maintenanceDto)
        {
            _ = _carServiceRepository.GetEntity(carServiceId).EntityNotFoundCheck();

            var maintenance = _maintenanceRepository.GetEntity(maintenanceId).EntityNotFoundCheck();

            maintenanceDto.CarServiceId = carServiceId;
            maintenanceDto.Id = maintenanceId;

            _updateMaintenanceValidator.ValidateAndThrow(maintenanceDto);
            _maintenanceRepository.Update(maintenance);
            _mapper.Map(maintenanceDto, maintenance);
            _unitOfWork.Commit();
        }

        public void UpdateMaintenancePatch(int carServiceId, int maintenanceId, JsonPatchDocument<UpdateMaintenanceDto> patchDocument)
        {
            _ = _carServiceRepository.GetEntity(carServiceId).EntityNotFoundCheck();

            var maintenance = _maintenanceRepository.GetEntity(maintenanceId).EntityNotFoundCheck();

            var maintenanceDto = _mapper.Map<UpdateMaintenanceDto>(maintenance);
            maintenanceDto.CarServiceId = carServiceId;
            maintenanceDto.Id = maintenanceId;

            patchDocument.ApplyTo(maintenanceDto);

            maintenanceDto.Id = maintenanceId;

            _updateMaintenanceValidator.ValidateAndThrow(maintenanceDto);
            _maintenanceRepository.Update(maintenance);
            _mapper.Map(maintenanceDto, maintenance);
            _unitOfWork.Commit();
        }

        public void DeleteMaintenance(int carServiceId, int maintenanceId)
        {
            _ = _carServiceRepository.GetEntity(carServiceId).EntityNotFoundCheck();
            var maintenance = _maintenanceRepository.GetEntity(maintenanceId).EntityNotFoundCheck();

            _maintenanceRepository.Delete(maintenance);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}
