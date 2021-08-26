using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ProjectCars.Repository
{
    public class EngineRepository : GenericRepository<Engine>, IEngineRepository
    {
        #region CONSTRUCTORS

        public EngineRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<EngineDto> GetAll(SearchEngineDto searchEngine)
        {
            var orderBy = searchEngine.OrderBy.Split(new[] { '-' })[0];
            var direction = searchEngine.OrderBy?.Split(new[] { '-' })[1];

            return (from e in Context.Engines
                    join f in Context.FuelTypes on e.FuelTypeId equals f.Id
                    where e.CubicCapacity <= searchEngine.CubicCapacityMax && e.CubicCapacity >= searchEngine.CubicCapacityMin
                    select new EngineDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        CubicCapacity = e.CubicCapacity,
                        Power = e.Power,
                        FuelTypeId = e.FuelTypeId,
                        FuelTypeName = f.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchEngine.PageNumber - 1) * searchEngine.PageSize)
                      .Take(searchEngine.PageSize).ToList();
        }

        public EngineDto GetOne(int id)
        {
            return (from e in Context.Engines
                    join f in Context.FuelTypes on e.FuelTypeId equals f.Id
                    where e.Id == id
                    select new EngineDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        CubicCapacity = e.CubicCapacity,
                        Power = e.Power,
                        FuelTypeId = e.FuelTypeId,
                        FuelTypeName = f.Name,
                    }).FirstOrDefault();
        }

        #endregion METHODS
    }
}