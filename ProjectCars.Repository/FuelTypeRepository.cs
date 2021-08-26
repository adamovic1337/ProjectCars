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
    public class FuelTypeRepository : GenericRepository<FuelType>, IFuelTypeRepository
    {
        #region CONSTRUCTORS

        public FuelTypeRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<FuelTypeDto> GetAll(SearchFuelTypeDto searchFuelType)
        {
            var orderBy = searchFuelType.OrderBy.Split(new[] { '-' })[0];
            var direction = searchFuelType.OrderBy?.Split(new[] { '-' })[1];

            return (from f in Context.FuelTypes
                    where f.Name.Contains(Strings.Trim(searchFuelType.FuelTypeName))
                    select new FuelTypeDto
                    {
                        Id = f.Id,
                        Name = f.Name
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchFuelType.PageNumber - 1) * searchFuelType.PageSize)
                      .Take(searchFuelType.PageSize).ToList();
        }

        public FuelTypeDto GetOne(int id)
        {
            return Context.FuelTypes.Where(f => f.Id == id).Select(f => new FuelTypeDto { Id = f.Id, Name = f.Name }).FirstOrDefault();
        } 

        #endregion
    }
}
