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
    public class CarsService : ICarsService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarRepository _carRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly CreateCarValidator _createCarValidator;
        private readonly UpdateCarValidator _updateCarValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CarsService(IUnitOfWork unitOfWork, ICarRepository carRepository, IMapper mapper, IUserRepository userRepository, CreateCarValidator createCarValidator, UpdateCarValidator updateCarValidator)
        {
            _unitOfWork = unitOfWork;
            _carRepository = carRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _createCarValidator = createCarValidator;
            _updateCarValidator = updateCarValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<CarDto> GetCars(int userId, SearchCarDto searchCar)
        {
            return _carRepository.GetAll(userId, searchCar);
        }

        public PaginationData<Car> PaginationData(int userId, SearchCarDto searchCar)
        {
            return _carRepository.GetPaginationData(userId, searchCar);
        }

        public CarDto GetCarById(int userId, int carId)
        {
            return _carRepository.GetOne(userId, carId).EntityNotFoundCheck();
        }

        public CarDto CreateCar(int userId, CreateCarDto carDto)
        {
            _createCarValidator.ValidateAndThrow(carDto);

            var carEntity = _mapper.Map<Car>(carDto);
            var userEntity = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            carEntity.UserCars = new List<UserCar> { new UserCar { Car = carEntity, User = userEntity } };

            _carRepository.Create(carEntity);
            _unitOfWork.Commit();

            var carToReturn = _carRepository.GetOne(userEntity.Id, carEntity.Id);

            return carToReturn;
        }

        public void UpdateCarPut(int userId, int carId, UpdateCarDto carDto)
        {
            _ = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            var car = _carRepository.GetEntity(carId).EntityNotFoundCheck();            

            carDto.Id = carId;

            _updateCarValidator.ValidateAndThrow(carDto);
            _carRepository.Update(car);
            _mapper.Map(carDto, car);
            _unitOfWork.Commit();
        }

        public void UpdateCarPatch(int userId, int carId, JsonPatchDocument<UpdateCarDto> patchDocument)
        {
            _ = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            var car = _carRepository.GetEntity(carId).EntityNotFoundCheck();

            var carDto = _mapper.Map<UpdateCarDto>(car);

            patchDocument.ApplyTo(carDto);

            carDto.Id = carId;

            _updateCarValidator.ValidateAndThrow(carDto);
            _carRepository.Update(car);
            _mapper.Map(carDto, car);
            _unitOfWork.Commit();
        }        

        public void DeleteCar(int userId, int carId)
        {
            var user = _userRepository.GetEntity(userId).EntityNotFoundCheck();
            var car = _carRepository.GetEntity(carId).EntityNotFoundCheck();

            car.UserCars = new List<UserCar> { new UserCar { Car = car, User = user } };

            _carRepository.Delete(car);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}