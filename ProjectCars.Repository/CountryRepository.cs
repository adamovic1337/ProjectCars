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
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        #region CONSTRUCTORS

        public CountryRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<CountryDto> GetAll(SearchCountryDto searchCountry)
        {
            var orderBy = searchCountry.OrderBy.Split(new[] { '-' })[0];
            var direction = searchCountry.OrderBy?.Split(new[] { '-' })[1];

            return (from c in Context.Countries
                    where c.Name.Contains(Strings.Trim(searchCountry.CountryName))
                    select new CountryDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchCountry.PageNumber - 1) * searchCountry.PageSize)
                      .Take(searchCountry.PageSize).ToList();
        }

        public CountryDto GetOne(int id)
        {
            return Context.Countries.Where(c => c.Id == id).Select(c => new CountryDto { Id = c.Id, Name = c.Name }).FirstOrDefault();
        }

        #endregion
    }
}
