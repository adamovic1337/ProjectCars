using Microsoft.VisualBasic;
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
    public class CarModelRepository : GenericRepository<CarModel>, ICarModelRepository
    {
        #region CONSTRUCTORS

        public CarModelRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<CarModelDto> GetAll(SearchCarModelDto searchCarModel)
        {
            var orderBy = searchCarModel.OrderBy.Split(new[] { '-' })[0];
            var direction = searchCarModel.OrderBy?.Split(new[] { '-' })[1];

            return (from cm in Context.CarModels
                    join e in Context.Engines on cm.EngineId equals e.Id
                    join m in Context.Manufacturers on cm.ManufacturerId equals m.Id
                    where cm.Name.Contains(Strings.Trim(searchCarModel.CarModelName))
                    select new CarModelDto
                    {
                        Id = cm.Id,
                        Name = cm.Name,
                        EngineId = cm.EngineId,
                        EngineName = e.Name,
                        ManufacturerId = cm.ManufacturerId,
                        ManufacturerName = m.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchCarModel.PageNumber - 1) * searchCarModel.PageSize)
                      .Take(searchCarModel.PageSize).ToList();
        }

        public CarModelDto GetOne(int id)
        {
            return (from cm in Context.CarModels
                    join e in Context.Engines on cm.EngineId equals e.Id
                    join m in Context.Manufacturers on cm.ManufacturerId equals m.Id
                    where cm.Id == id
                    select new CarModelDto
                    {
                        Id = cm.Id,
                        Name = cm.Name,
                        EngineId = cm.EngineId,
                        EngineName = e.Name,
                        ManufacturerId = cm.ManufacturerId,
                        ManufacturerName = m.Name,
                    }).FirstOrDefault();
        }

        #endregion METHODS
    }
}