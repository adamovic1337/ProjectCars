using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.DbContexts;
using ProjectCars.Repository.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ProjectCars.Repository
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        #region CONSTRUCTORS

        public CarRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<CarDto> GetAll(int userId, SearchCarDto searchCar)
        {
            var orderBy = searchCar.OrderBy.Split(new[] { '-' })[0];
            var direction = searchCar.OrderBy?.Split(new[] { '-' })[1];

            return (from c in Context.Cars
                    join uc in Context.UserCars on c.Id equals uc.CarId
                    join u in Context.Users on uc.UserId equals u.Id
                    join cm in Context.CarModels on c.ModelId equals cm.Id
                    join e in Context.Engines on cm.EngineId equals e.Id
                    join f in Context.FuelTypes on e.FuelTypeId equals f.Id
                    join m in Context.Manufacturers on cm.ManufacturerId equals m.Id

                    where u.Id == userId && cm.Name.Contains(searchCar.ModelName.Trim())

                    select new CarDto
                    {
                        Id = c.Id,
                        Vin = c.Vin,
                        FirstRegistration = c.FirstRegistration.Date.ToString(),
                        Mileage = c.Mileage,
                        ModelId = c.ModelId,
                        ModelName = cm.Name,
                        EngineId = e.Id,
                        EngineName = e.Name,
                        CubicCapacity = e.CubicCapacity,
                        Power = e.Power,
                        FuelTypeId = f.Id,
                        FuelTypeName = f.Name,
                        ManufacturerId = m.Id,
                        ManufacturerName = m.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchCar.PageNumber - 1) * searchCar.PageSize)
                      .Take(searchCar.PageSize).ToList();
        }

        public PaginationData<Car> GetPaginationData(int userId, SearchCarDto searchCar)
        {
            var query = (from c in Context.Cars
                         join uc in Context.UserCars on c.Id equals uc.CarId
                         join u in Context.Users on uc.UserId equals u.Id
                         join cm in Context.CarModels on c.ModelId equals cm.Id
                         where u.Id == userId && cm.Name.Contains(searchCar.ModelName.Trim())
                         select new Car
                         {
                             Id = c.Id,
                             Vin = c.Vin,
                             FirstRegistration = c.FirstRegistration,
                             Mileage = c.Mileage,
                             ModelId = c.ModelId,
                         });

            return PaginationData<Car>.Create(query, searchCar.PageNumber, searchCar.PageSize);
        }

        public CarDto GetOne(int userId, int carId)
        {            
            return (from c in Context.Cars
                    join uc in Context.UserCars on c.Id equals uc.CarId
                    join u in Context.Users on uc.UserId equals u.Id
                    join cm in Context.CarModels on c.ModelId equals cm.Id
                    join e in Context.Engines on cm.EngineId equals e.Id
                    join f in Context.FuelTypes on e.FuelTypeId equals f.Id
                    join m in Context.Manufacturers on cm.ManufacturerId equals m.Id

                    where u.Id == userId && c.Id == carId

                    select new CarDto
                    {
                        Id = c.Id,
                        Vin = c.Vin,
                        FirstRegistration = c.FirstRegistration.Date.ToString(),
                        Mileage = c.Mileage,
                        ModelId = c.ModelId,
                        ModelName = cm.Name,
                        EngineId = e.Id,
                        EngineName = e.Name,
                        CubicCapacity = e.CubicCapacity,
                        Power = e.Power,
                        FuelTypeId = f.Id,
                        FuelTypeName = f.Name,
                        ManufacturerId = m.Id,
                        ManufacturerName = m.Name,
                    }).FirstOrDefault();
        }       

        public Car GetEntity(int userId, int carId)
        {
            return (from c in Context.Cars
                    join cu in Context.UserCars on c.Id equals cu.CarId
                    join u in Context.Users on cu.UserId equals u.Id
                    join m in Context.CarModels on c.ModelId equals m.Id
                    where u.Id == userId && c.Id == carId

                    select new Car
                    {
                        Id = c.Id,
                        Vin = c.Vin,
                        FirstRegistration = c.FirstRegistration,
                        Mileage = c.Mileage,
                        ModelId = c.ModelId,
                    }).FirstOrDefault();
        }

        #endregion METHODS
    }
}