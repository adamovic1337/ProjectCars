using Microsoft.EntityFrameworkCore;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCars.Repository
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(ProjectCarsContext context) : base(context)
        {
        }

        public CarDto GetOne(int userId, int carId)
        {
            return (from c in Context.Cars
                    join cu in Context.UserCars on c.Id equals cu.CarId
                    join u in Context.Users on cu.UserId equals u.Id
                    join m in Context.CarModels on c.ModelId equals m.Id
                    where u.Id == userId && c.Id == carId

                    select new CarDto
                    {
                        Id = c.Id,
                        Vin = c.Vin,
                        FirstRegistration = c.FirstRegistration,
                        Mileage = c.Mileage,
                        ModelId = c.ModelId,
                        ModelName = m.Name,
                    }).FirstOrDefault();            
        }
    }
}