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
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        #region CONSTRUCTORS

        public ManufacturerRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<ManufacturerDto> GetAll(SearchManufacturerDto searchManufacturer)
        {
            var orderBy = searchManufacturer.OrderBy.Split(new[] { '-' })[0];
            var direction = searchManufacturer.OrderBy?.Split(new[] { '-' })[1];

            return (from m in Context.Manufacturers
                    join c in Context.Countries on m.CountryId equals c.Id
                    where m.Name.Contains(searchManufacturer.ManufacturerName.Trim())
                    select new ManufacturerDto
                    {
                        Id = m.Id,
                        Name = m.Name,
                        CountryId = m.CountryId,
                        CountryName = c.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchManufacturer.PageNumber - 1) * searchManufacturer.PageSize)
                      .Take(searchManufacturer.PageSize).ToList();
        }

        public ManufacturerDto GetOne(int id)
        {
            return (from m in Context.Manufacturers
                    join c in Context.Countries on m.CountryId equals c.Id
                    where m.Id == id
                    select new ManufacturerDto
                    {
                        Id = m.Id,
                        Name = m.Name,
                        CountryId = m.CountryId,
                        CountryName = c.Name,
                    }).FirstOrDefault();
        } 
        #endregion
    }
}
