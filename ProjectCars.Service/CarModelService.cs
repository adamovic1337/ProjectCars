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
    public class CarModelService : ICarModelService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<CarModel> _carModelRepository;
        private readonly IMapper _mapper;
        private readonly CreateCarModelValidator _createCarModelValidator;
        private readonly UpdateCarModelValidator _updateCarModelValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CarModelService(IUnitOfWork unitOfWork, IGenericRepository<CarModel> carModelRepository, IMapper mapper, CreateCarModelValidator createcarModelValidator, UpdateCarModelValidator updatecarModelValidator)
        {
            _unitOfWork = unitOfWork;
            _carModelRepository = carModelRepository;
            _mapper = mapper;
            _createCarModelValidator = createcarModelValidator;
            _updateCarModelValidator = updatecarModelValidator;
        }

        #endregion

        #region METHODS
        
        public IEnumerable<CarModelDto> GetCarModels(SearchCarModelDto searchCarModel)
        {
            var orderBy = searchCarModel.OrderBy.Split(new[] { '-' })[0];
            var direction = searchCarModel.OrderBy?.Split(new[] { '-' })[1];

            var carModels = _carModelRepository.GetAll(searchCarModel.PageNumber, 
                                                       searchCarModel.PageSize,
                                                       c => c.Name.Contains(Strings.Trim(searchCarModel.CarModelName)),
                                                       q => q.OrderBy($"{orderBy} {direction}"));

            return _mapper.Map<IEnumerable<CarModelDto>>(carModels);
        }

        public PagedList<CarModel> PagedListCarModels(SearchCarModelDto searchCarModel)
        {
            return _carModelRepository.GetAll(searchCarModel.PageNumber, 
                                              searchCarModel.PageSize, 
                                              c => c.Name.Contains(Strings.Trim(searchCarModel.CarModelName)));
        }

        public CarModelDto GetCarModelById(int carModelId)
        {
            var carModel = _carModelRepository.GetOne(carModelId).EntityNotFoundCheck();

            return _mapper.Map<CarModelDto>(carModel);
        }

        public CarModelDto CreateCarModel(CreateCarModelDto carModelDto)
        {
            _createCarModelValidator.ValidateAndThrow(carModelDto);

            var carModelEntity = _mapper.Map<CarModel>(carModelDto);
            _carModelRepository.Create(carModelEntity);
            _unitOfWork.Commit();

            var carModelToReturn = _mapper.Map<CarModelDto>(carModelEntity);
            return carModelToReturn;
        }

        public void UpdateCarModelPut(int carModelId, UpdateCarModelDto carModelDto)
        {
            var carModel = _carModelRepository.GetOne(carModelId).EntityNotFoundCheck();

            carModelDto.Id = carModelId;

            _updateCarModelValidator.ValidateAndThrow(carModelDto);
            _carModelRepository.Update(carModel);
            _mapper.Map(carModelDto, carModel);
            _unitOfWork.Commit();
        }

        public void UpdateCarModelPatch(int carModelId, JsonPatchDocument<UpdateCarModelDto> patchDocument)
        {
            var carModel = _carModelRepository.GetOne(carModelId).EntityNotFoundCheck();

            var carModelDto = _mapper.Map<UpdateCarModelDto>(carModel);

            patchDocument.ApplyTo(carModelDto);

            carModelDto.Id = carModelId;

            _updateCarModelValidator.ValidateAndThrow(carModelDto);
            _carModelRepository.Update(carModel);
            _mapper.Map(carModelDto, carModel);
            _unitOfWork.Commit();
        }

        public void DeleteCarModel(int carModelId)
        {
            _carModelRepository.GetOne(carModelId).EntityNotFoundCheck();

            _carModelRepository.Delete(carModelId);
            _unitOfWork.Commit();
        }

        #endregion
    }
}
