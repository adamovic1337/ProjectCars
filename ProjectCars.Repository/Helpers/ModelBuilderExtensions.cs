using Bogus;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using ProjectCars.Model.Entities;
using System.Linq;

namespace ProjectCars.Repository.Helpers
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Seeding database with fake data using Bogus library
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void SeedDatabaseWithFakeData(this ModelBuilder modelBuilder)
        {
            #region COUNTRIES

            var countryId = 1;

            var country = new Faker<Country>()
                .RuleFor(c => c.Id, _ => countryId++)
                .RuleFor(c => c.Name, f => f.Address.Country());

            var generateCountries = country.Generate(200);
            var uniqueCountries = generateCountries.DistinctBy(c => c.Name).ToList();
            var countriesIds = uniqueCountries.Select(c => c.Id).ToList();

            modelBuilder.Entity<Country>().HasData(uniqueCountries);

            #endregion COUNTRIES

            #region CITIES

            var cityId = 1;

            var city = new Faker<City>()
                .RuleFor(c => c.Id, _ => cityId++)
                .RuleFor(c => c.Name, f => f.Address.City())
                .RuleFor(c => c.CountryId, f => f.PickRandom(countriesIds));

            var generateCities = city.Generate(300);
            var uniqueCities = generateCities.DistinctBy(c => c.Name).ToList();
            var citiesIds = uniqueCities.Select(c => c.Id).ToList();

            modelBuilder.Entity<City>().HasData(uniqueCities);

            #endregion CITIES

            #region ROLES

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "User"
                },
                new Role
                {
                    Id = 3,
                    Name = "ServiceOwner"
                });

            #endregion ROLES

            #region USERS

            var userId = 1;
            var user = new Faker<User>()
                .RuleFor(u => u.Id, _ => userId++)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, (f) => f.Internet.Email())
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.CityId, f => f.PickRandom(citiesIds))
                .RuleFor(u => u.RoleId, f => f.PickRandom(1, 2, 3));

            var generateUsers = user.Generate(300);
            var uniqueUsersByEmail = generateUsers.DistinctBy(u => u.Email).ToList();
            var uniqueUsers = uniqueUsersByEmail.DistinctBy(u => u.Username).ToList();
            var carOwnersIds = uniqueUsers.Where(u => u.RoleId == 2).Select(u => u.Id).ToList();
            var carServiceOwnersIds = uniqueUsers.Where(u => u.RoleId == 3).Select(u => u.Id).ToList();

            modelBuilder.Entity<User>().HasData(uniqueUsers);

            #endregion USERS

            #region CAR SERVICES

            var carServiceId = 1;
            var carService = new Faker<CarService>()
                .RuleFor(cs => cs.Id, _ => carServiceId++)
                .RuleFor(cs => cs.Name, f => f.Company.CompanyName())
                .RuleFor(cs => cs.Phone, f => f.Phone.PhoneNumber("(###) ###-####"))
                .RuleFor(cs => cs.Address, f => f.Address.StreetName())
                .RuleFor(cs => cs.Email, f => f.Internet.Email())
                .RuleFor(cs => cs.Website, (_, cs) => $"www.{cs.Name}.com")
                .RuleFor(cs => cs.CityId, f => f.PickRandom(citiesIds))
                .RuleFor(cs => cs.OwnerId, f => f.PickRandom(carServiceOwnersIds));

            var generateCarServices = carService.Generate(150);
            var uniqueCarServicesByEmail = generateCarServices.DistinctBy(cs => cs.Email).ToList();
            var uniqueCarServices = uniqueCarServicesByEmail.DistinctBy(cs => cs.Name).ToList();
            var carServicesIds = uniqueCarServices.Select(cs => cs.Id).ToList();

            modelBuilder.Entity<CarService>().HasData(uniqueCarServices);

            #endregion CAR SERVICES

            #region MANUFACTURERS

            var manufacturerId = 1;

            var manufacturer = new Faker<Manufacturer>()
                .RuleFor(m => m.Id, _ => manufacturerId++)
                .RuleFor(m => m.Name, f => f.Company.CompanyName())
                .RuleFor(m => m.CountryId, f => f.PickRandom(countriesIds));

            var generateManufacturers = manufacturer.Generate(100);
            var uniqueManufacturers = generateManufacturers.DistinctBy(c => c.Name).ToList();
            var manufacturersIds = uniqueManufacturers.Select(c => c.Id).ToList();

            modelBuilder.Entity<Manufacturer>().HasData(uniqueManufacturers);

            #endregion MANUFACTURERS

            #region FUEL TYPES

            modelBuilder.Entity<FuelType>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Diesel"
                },
                new Role
                {
                    Id = 2,
                    Name = "Petrol"
                },
                new Role
                {
                    Id = 3,
                    Name = "Petrol + LPG"
                },
                new Role
                {
                    Id = 4,
                    Name = "Electric"
                });

            #endregion FUEL TYPES

            #region ENGINES

            var engineId = 1;

            var engine = new Faker<Engine>()
                .RuleFor(e => e.Id, _ => engineId++)
                .RuleFor(e => e.CubicCapacity, f => f.Random.Int(999, 3000))
                .RuleFor(e => e.Power, f => f.Random.Int(100, 700))
                .RuleFor(e => e.FuelTypeId, f => f.PickRandom(1, 2, 3, 4));

            var generateEngines = engine.Generate(100);
            var enginesIds = generateEngines.Select(c => c.Id).ToList();

            modelBuilder.Entity<Engine>().HasData(generateEngines);

            #endregion ENGINES

            #region MODELS

            var modelId = 1;

            var model = new Faker<CarModel>()
                .RuleFor(m => m.Id, _ => modelId++)
                .RuleFor(m => m.Name, f => f.Lorem.Word())
                .RuleFor(m => m.ManufacturerId, f => f.PickRandom(manufacturersIds))
                .RuleFor(m => m.EngineId, f => f.PickRandom(enginesIds));

            var generateModels = model.Generate(100);
            var uniqueModels = generateModels.DistinctBy(m => m.Name).ToList();
            var modelsIds = uniqueModels.Select(c => c.Id).ToList();

            modelBuilder.Entity<CarModel>().HasData(uniqueModels);

            #endregion MODELS

            #region CARS

            var carId = 1;
            var car = new Faker<Car>()
                .RuleFor(c => c.Id, _ => carId++)
                .RuleFor(c => c.Vin, f => f.Random.Int(1000000, 9999999).ToString())
                .RuleFor(c => c.FirstRegistration, f => f.Date.Past())
                .RuleFor(c => c.Mileage, f => f.Random.Int(0, 999999))
                .RuleFor(c => c.ModelId, f => f.PickRandom(modelsIds));

            var generateCars = car.Generate(carServiceOwnersIds.Count);
            var uniqueCars = generateCars.DistinctBy(c => c.Vin).ToList();
            var carsIds = uniqueCars.Select(cs => cs.Id).ToList();

            modelBuilder.Entity<Car>().HasData(uniqueCars);

            #endregion CARS

            #region USER CARS

            var userCarId = 1;
            var userCar = new Faker<UserCar>()
                .RuleFor(uc => uc.Id, _ => userCarId++)
                .RuleFor(uc => uc.CarId, f => f.PickRandom(carsIds))
                .RuleFor(uc => uc.UserId, f => f.PickRandom(carOwnersIds));

            var generateUserCars = userCar.Generate(carServiceOwnersIds.Count);
            var uniqueUserCars = generateUserCars.DistinctBy(c => c.CarId).ToList();
            var userCarsIds = uniqueUserCars.Select(c => c.Id).ToList();

            modelBuilder.Entity<UserCar>().HasData(uniqueUserCars);

            #endregion USER CARS

            #region MAINTENANCE

            var maintenanceId = 1;

            var maintenance = new Faker<Maintenance>()
                .RuleFor(m => m.Id, _ => maintenanceId++)
                .RuleFor(m => m.Repairs, f => f.Lorem.Text())
                .RuleFor(m => m.RepairDate, f => f.Date.Past())
                .RuleFor(m => m.Mileage, f => f.Random.Int(0, 999999))
                .RuleFor(m => m.CarId, f => f.PickRandom(carsIds))
                .RuleFor(m => m.CarServiceId, f => f.PickRandom(carServicesIds));

            var generateMaintenance = maintenance.Generate(600);

            modelBuilder.Entity<Maintenance>().HasData(generateMaintenance);

            #endregion MAINTENANCE

            #region STATUS

            modelBuilder.Entity<Status>().HasData(
               new Status
               {
                   Id = 1,
                   Name = "Pending"
               },
               new Status
               {
                   Id = 2,
                   Name = "Accepted"
               },
               new Status
               {
                   Id = 3,
                   Name = "Repairing"
               },
               new Status
               {
                   Id = 4,
                   Name = "Ready for pick up"
               },
               new Status
               {
                   Id = 5,
                   Name = "Completed"
               });

            #endregion STATUS

            #region SERVICE REQUEST

            var serviceRequestId = 1;

            var serviceRequest = new Faker<ServiceRequest>()
                .RuleFor(sr => sr.Id, _ => serviceRequestId++)
                .RuleFor(sr => sr.UserDescription, f => f.Lorem.Text())
                .RuleFor(sr => sr.Appointment, f => f.Date.Past())
                .RuleFor(sr => sr.RepairStart, f => f.Date.Past())
                .RuleFor(sr => sr.RepairEnd, f => f.Date.Future())
                .RuleFor(sr => sr.CarServiceId, f => f.PickRandom(carServicesIds))
                .RuleFor(sr => sr.UserCarId, f => f.PickRandom(userCarsIds))
                .RuleFor(sr => sr.StatusId, f => f.PickRandom(1, 2, 3, 4, 5));

            var generateServiceRequest = serviceRequest.Generate(200);

            modelBuilder.Entity<ServiceRequest>().HasData(generateServiceRequest);

            #endregion SERVICE REQUEST
        }
    }
}