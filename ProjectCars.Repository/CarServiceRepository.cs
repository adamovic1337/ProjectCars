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
    public class CarServiceRepository : GenericRepository<CarService>, ICarServiceRepository
    {
        #region CONSTRUCTORS

        public CarServiceRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<CarServiceDto> GetAll(SearchCarServiceDto searchCarService)
        {
            var orderBy = searchCarService.OrderBy.Split(new[] { '-' })[0];
            var direction = searchCarService.OrderBy?.Split(new[] { '-' })[1];

            return (from cs in Context.CarServices
                    join u in Context.Users on cs.OwnerId equals u.Id
                    join c in Context.Cities on u.CityId equals c.Id
                    where cs.Name.Contains(searchCarService.CarServiceName.Trim())
                    select new CarServiceDto
                    {
                        Id = cs.Id,
                        Name = cs.Name,
                        Phone = cs.Phone,
                        Address = cs.Address,
                        Email = cs.Email,
                        Website = cs.Website,
                        CityId = cs.CityId,
                        CityName = c.Name,
                        OwnerId = cs.OwnerId,
                        OwnerName = $"{u.FirstName} {u.LastName}",
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchCarService.PageNumber - 1) * searchCarService.PageSize)
                      .Take(searchCarService.PageSize).ToList();
        }

        public CarServiceDto GetOne(int id)
        {
            return (from cs in Context.CarServices
                    join u in Context.Users on cs.OwnerId equals u.Id
                    join c in Context.Cities on u.CityId equals c.Id
                    where cs.Id == id
                    select new CarServiceDto
                    {
                        Id = cs.Id,
                        Name = cs.Name,
                        Phone = cs.Phone,
                        Address = cs.Address,
                        Email = cs.Email,
                        Website = cs.Website,
                        CityId = cs.CityId,
                        CityName = c.Name,
                        OwnerId = cs.OwnerId,
                        OwnerName = $"{u.FirstName} {u.LastName}",
                    }).FirstOrDefault();
        }

        public CarServiceDto GetOneByOwner(int id)
        {
            return (from cs in Context.CarServices
                    join u in Context.Users on cs.OwnerId equals u.Id
                    join c in Context.Cities on u.CityId equals c.Id
                    where cs.OwnerId == id
                    select new CarServiceDto
                    {
                        Id = cs.Id,
                        Name = cs.Name,
                        Phone = cs.Phone,
                        Address = cs.Address,
                        Email = cs.Email,
                        Website = cs.Website,
                        CityId = cs.CityId,
                        CityName = c.Name,
                        OwnerId = cs.OwnerId,
                        OwnerName = $"{u.FirstName} {u.LastName}",
                    }).FirstOrDefault();
        }

        #endregion METHODS
    }
}