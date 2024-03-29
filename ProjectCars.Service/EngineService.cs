﻿using AutoMapper;
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
    public class EngineService : IEngineService
    {
        #region FIELDS

        private readonly IEngineRepository _engineRepository;
        private readonly IMapper _mapper;
        private readonly CreateEngineValidator _createEngineValidator;
        private readonly UpdateEngineValidator _updateEngineValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public EngineService(IEngineRepository engineRepository, IMapper mapper, CreateEngineValidator createEngineValidator, UpdateEngineValidator updateEngineValidator)
        {
            _engineRepository = engineRepository;
            _mapper = mapper;
            _createEngineValidator = createEngineValidator;
            _updateEngineValidator = updateEngineValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<EngineDto> GetEngines(SearchEngineDto searchEngine)
        {
            return _engineRepository.GetAll(searchEngine);
        }

        public PaginationData<Engine> PaginationData(SearchEngineDto searchEngine)
        {
            return _engineRepository.GetPaginationData(searchEngine,
                                                       e => e.Name.Contains(searchEngine.EngineName.Trim()));
        }

        public EngineDto GetEngineById(int engineId)
        {
            return _engineRepository.GetOne(engineId).EntityNotFoundCheck();
        }

        public EngineDto CreateEngine(CreateEngineDto engineDto)
        {
            _createEngineValidator.ValidateAndThrow(engineDto);

            var engineEntity = _mapper.Map<Engine>(engineDto);
            _engineRepository.Create(engineEntity);
            _engineRepository.Save();

            var engineToReturn = _mapper.Map<EngineDto>(engineEntity);
            return engineToReturn;
        }

        public void UpdateEnginePut(int engineId, UpdateEngineDto engineDto)
        {
            var engine = _engineRepository.GetEntity(engineId).EntityNotFoundCheck();

            engineDto.Id = engineId;

            _updateEngineValidator.ValidateAndThrow(engineDto);
            _engineRepository.Update(engine);
            _mapper.Map(engineDto, engine);
            _engineRepository.Save();
        }

        public void UpdateEnginePatch(int engineId, JsonPatchDocument<UpdateEngineDto> patchDocument)
        {
            var engine = _engineRepository.GetEntity(engineId).EntityNotFoundCheck();

            var engineDto = _mapper.Map<UpdateEngineDto>(engine);

            patchDocument.ApplyTo(engineDto);

            engineDto.Id = engineId;

            _updateEngineValidator.ValidateAndThrow(engineDto);
            _engineRepository.Update(engine);
            _mapper.Map(engineDto, engine);
            _engineRepository.Save();
        }

        public void DeleteEngine(int engineId)
        {
            var engine = _engineRepository.GetEntity(engineId).EntityNotFoundCheck();

            _engineRepository.Delete(engine);
            _engineRepository.Save();
        }

        #endregion METHODS
    }
}