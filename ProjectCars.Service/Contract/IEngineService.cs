using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Helpers;
using System.Collections.Generic;

namespace ProjectCars.Service.Contract
{
    public interface IEngineService
    {
        /// <summary>
        /// Returns all Engines based on user filters
        /// </summary>
        /// <param name="searchEngine"></param>
        /// <returns>Returns collection of Engine></returns>
        List<EngineDto> GetEngines(SearchEngineDto searchEngine);

        /// <summary>
        /// Return Pagination Data for creating X-Pagination header
        /// </summary>
        /// <param name="searchEngine"></param>
        /// <returns>Returns PagedList of Engines</returns>
        PaginationData<Engine> PaginationData(SearchEngineDto searchEngine);

        /// <summary>
        /// Returns one Engine
        /// </summary>
        /// <param name="engineId"></param>
        /// <returns>Returns one Engine object</returns>
        EngineDto GetEngineById(int engineId);

        /// <summary>
        /// Creates Engine entity
        /// </summary>
        /// <param name="engineDto"></param>
        /// <returns>Created Engine for Location header</returns>
        EngineDto CreateEngine(CreateEngineDto engineDto);

        /// <summary>
        /// Update Engine using PUT method entity
        /// </summary>
        /// <param name="engineId"></param>
        /// <param name="engineDto"></param>
        void UpdateEnginePut(int engineId, UpdateEngineDto engineDto);

        /// <summary>
        /// Update Engine using PATCH method entity
        /// </summary>
        /// <param name="engineId"></param>
        /// <param name="patchDocument"></param>
        void UpdateEnginePatch(int engineId, JsonPatchDocument<UpdateEngineDto> patchDocument);

        /// <summary>
        /// Delete Engine
        /// </summary>
        /// <param name="engineId"></param>
        void DeleteEngine(int engineId);
    }
}
