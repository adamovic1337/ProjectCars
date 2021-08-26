using AutoMapper;
using ProjectCars.Model.DTO.View;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.Contracts;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Helpers;

namespace ProjectCars.Service
{
    public class CarsService : ICarsService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        //private readonly CreateCarValidator _createUserValidator;
        //private readonly UpdateCarValidator _updateUserValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CarsService(IUnitOfWork unitOfWork, ICarRepository carRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public CarDto GetCarById(int userId, int carId)
        {
            return _carRepository.GetOne(userId, carId).EntityNotFoundCheck();             
        }

        #endregion
    }
}