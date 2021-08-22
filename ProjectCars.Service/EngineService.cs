using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
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
    public class EngineService : IEngineService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Engine> _engineRepository;
        private readonly IMapper _mapper;
        private readonly CreateEngineValidator _createEngineValidator;
        private readonly UpdateEngineValidator _updateEngineValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public EngineService(IUnitOfWork unitOfWork, IGenericRepository<Engine> engineRepository, IMapper mapper, CreateEngineValidator createEngineValidator, UpdateEngineValidator updateEngineValidator)
        {
            _unitOfWork = unitOfWork;
            _engineRepository = engineRepository;
            _mapper = mapper;
            _createEngineValidator = createEngineValidator;
            _updateEngineValidator = updateEngineValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public IEnumerable<EngineDto> GetEngines(SearchEngineDto searchEngine)
        {
            var orderBy = searchEngine.OrderBy.Split(new[] { '-' })[0];
            var direction = searchEngine.OrderBy?.Split(new[] { '-' })[1];

            var engines = _engineRepository.GetAll(searchEngine.PageNumber, 
                                                   searchEngine.PageSize,
                                                   e => e.CubicCapacity <= searchEngine.CubicCapacityMax && e.CubicCapacity >= searchEngine.CubicCapacityMin,
                                                   q => q.OrderBy($"{orderBy} {direction}"));

            return _mapper.Map<IEnumerable<EngineDto>>(engines);
        }

        public PagedList<Engine> PagedListEngines(SearchEngineDto searchEngine)
        {
            return _engineRepository.GetAll(searchEngine.PageNumber, 
                                            searchEngine.PageSize, 
                                            e => e.CubicCapacity <= searchEngine.CubicCapacityMax && e.CubicCapacity >= searchEngine.CubicCapacityMin);
        }

        public EngineDto GetEngineById(int engineId)
        {
            var engine = _engineRepository.GetOne(engineId).EntityNotFoundCheck();

            return _mapper.Map<EngineDto>(engine);
        }

        public EngineDto CreateEngine(CreateEngineDto engineDto)
        {
            _createEngineValidator.ValidateAndThrow(engineDto);

            var engineEntity = _mapper.Map<Engine>(engineDto);
            _engineRepository.Create(engineEntity);
            _unitOfWork.Commit();

            var engineToReturn = _mapper.Map<EngineDto>(engineEntity);
            return engineToReturn;
        }

        public void UpdateEnginePut(int engineId, UpdateEngineDto engineDto)
        {
            var engine = _engineRepository.GetOne(engineId).EntityNotFoundCheck();

            engineDto.Id = engineId;

            _updateEngineValidator.ValidateAndThrow(engineDto);
            _engineRepository.Update(engine);
            _mapper.Map(engineDto, engine);
            _unitOfWork.Commit();
        }

        public void UpdateEnginePatch(int engineId, JsonPatchDocument<UpdateEngineDto> patchDocument)
        {
            var engine = _engineRepository.GetOne(engineId).EntityNotFoundCheck();

            var engineDto = _mapper.Map<UpdateEngineDto>(engine);

            patchDocument.ApplyTo(engineDto);

            engineDto.Id = engineId;

            _updateEngineValidator.ValidateAndThrow(engineDto);
            _engineRepository.Update(engine);
            _mapper.Map(engineDto, engine);
            _unitOfWork.Commit();
        }

        public void DeleteEngine(int engineId)
        {
            _engineRepository.GetOne(engineId).EntityNotFoundCheck();

            _engineRepository.Delete(engineId);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}