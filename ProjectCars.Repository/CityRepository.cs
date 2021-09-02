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
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        #region CONSTRUCTORS

        public CityRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<CityDto> GetAll(SearchCityDto searchCity)
        {
            var orderBy = searchCity.OrderBy.Split(new[] { '-' })[0];
            var direction = searchCity.OrderBy?.Split(new[] { '-' })[1];

            return (from c in Context.Cities
                    join co in Context.Countries on c.CountryId equals co.Id
                    where c.Name.Contains(searchCity.CityName.Trim())
                    select new CityDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CountryId = c.CountryId,
                        CountryName = co.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchCity.PageNumber - 1) * searchCity.PageSize)
                      .Take(searchCity.PageSize).ToList();
        }

        public CityDto GetOne(int id)
        {
            return (from c in Context.Cities
                    join co in Context.Countries on c.CountryId equals co.Id
                    where c.Id == id
                    select new CityDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CountryId = c.CountryId,
                        CountryName = co.Name,
                    }).FirstOrDefault();
        }

        #endregion METHODS
    }
}