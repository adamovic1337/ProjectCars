using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using ProjectCars.Model.Entities;
using System;
using System.IO;
using System.Linq;

namespace ProjectCars.Repository.Helpers
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Create script with fake data using Bogus library
        /// </summary>
        /// <param name="modelBuilder"></param>
        ///
        public static void CreateScriptWithFakeData(this ModelBuilder modelBuilder)
        {
            Directory.CreateDirectory("../SQL");
            File.WriteAllText("../SQL/SqlData.sql", "");

            #region COUNTRIES

            var country = new Faker<Country>()
                .RuleFor(c => c.Name, f => f.Address.Country());

            var generateCountries = country.Generate(200);
            var uniqueCountries = generateCountries.DistinctBy(c => c.Name).ToList();
            var totalCountries = uniqueCountries.Count;

            var SQL1 = $"--------------------< Total count: {totalCountries} >--------------------{Environment.NewLine}INSERT INTO dbo.Countries{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastCountry = uniqueCountries.Last();
            foreach (var item in uniqueCountries)
            {
                if (item.Equals(lastCountry))
                {
                    SQL1 += $"('{item.Name.Replace("'", " ")}');{Environment.NewLine}";
                }
                else
                {
                    SQL1 += $"('{item.Name.Replace("'", " ")}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL1);

            #endregion COUNTRIES

            #region CITIES

            var city = new Faker<City>()
                .RuleFor(c => c.Name, f => f.Address.City())
                .RuleFor(c => c.CountryId, f => f.Random.Int(1, totalCountries));

            var generateCities = city.Generate(300);
            var uniqueCities = generateCities.DistinctBy(c => c.Name).ToList();
            var totalCities = uniqueCities.Count;

            var SQL2 = $"--------------------< Total count: {totalCities} >--------------------{Environment.NewLine}INSERT INTO dbo.Cities{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastCity = uniqueCities.Last();
            foreach (var item in uniqueCities)
            {
                if (item.Equals(lastCity))
                {
                    SQL2 += $"('{item.Name.Replace("'", " ")}','{item.CountryId}');{Environment.NewLine}";
                }
                else
                {
                    SQL2 += $"('{item.Name.Replace("'", " ")}','{item.CountryId}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL2);

            #endregion CITIES

            #region ROLES
            var totalRoles = 3;
            var SQL3 = $"--------------------< Total count: {totalRoles} >--------------------{Environment.NewLine}" +
                       $"INSERT INTO dbo.AspNetRoles{Environment.NewLine}" +
                       $"(Name,NormalizedName){Environment.NewLine}" +
                       $"VALUES{Environment.NewLine}" +
                       $"('Admin','ADMIN'),{Environment.NewLine}" +
                       $"('User','USER'),{Environment.NewLine}" +
                       $"('ServiceOwner','SERVICEOWNER');{Environment.NewLine}";

            File.AppendAllText("../SQL/SqlData.sql", SQL3);

            #endregion ROLES

            #region USERS

            var user = new Faker<AppUser>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, (f) => f.Internet.Email())
                .RuleFor(u => u.UserName, f => f.Internet.UserName())
                .RuleFor(u => u.PasswordHash, f => "Password123!")
                .RuleFor(u => u.CityId, f => f.Random.Int(1, totalCities));

            var generateUsers = user.Generate(200);
            var uniqueUsersByEmail = generateUsers.DistinctBy(u => u.Email).ToList();
            var uniqueUsers = uniqueUsersByEmail.DistinctBy(u => u.UserName).ToList();
            var totalUsers = uniqueUsers.Count;

            var SQL4 = $"--------------------< Total count: {totalUsers} >--------------------{Environment.NewLine}INSERT INTO dbo.AspNetUsers{Environment.NewLine}" +
                       $"(FirstName,LastName,Email,UserName,PasswordHash,CityId,EmailConfirmed,PhoneNumberConfirmed,AccessFailedCount,TwoFactorEnabled,LockoutEnabled){Environment.NewLine}" +
                       $"VALUES{Environment.NewLine}";

            var lastUser = uniqueUsers.Last();
            foreach (var item in uniqueUsers)
            {
                if (item.Equals(lastUser))
                {
                    SQL4 += $"('{item.FirstName.Replace("'", " ")}','{item.LastName.Replace("'", " ")}','{item.Email}','{item.UserName}','{item.PasswordHash}','{item.CityId}','{item.EmailConfirmed = false}','{item.PhoneNumberConfirmed = false}','{item.AccessFailedCount = 0}','{item.TwoFactorEnabled = false}','{item.LockoutEnabled = false}');{Environment.NewLine}";
                }
                else
                {
                    SQL4 += $"('{item.FirstName.Replace("'", " ")}','{item.LastName.Replace("'", " ")}','{item.Email}','{item.UserName}','{item.PasswordHash}','{item.CityId}','{item.EmailConfirmed = false}','{item.PhoneNumberConfirmed = false}','{item.AccessFailedCount = 0}','{item.TwoFactorEnabled = false}','{item.LockoutEnabled = false}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL4);

            #endregion USERS

            #region USER ROLES

            var userRole = new Faker<IdentityUserRole<int>>()
                .RuleFor(ur => ur.UserId, f => f.Random.Int(1, totalUsers))
                .RuleFor(ur => ur.RoleId, f => f.Random.Int(1, totalRoles));

            var generateUserRoles = userRole.Generate(totalUsers);
            var uniqueUserRoles = generateUserRoles.DistinctBy(u => u.UserId).ToList();
            var totalUserRoles = uniqueUserRoles.Count;

            var carOwnersIds = uniqueUserRoles.Where(u => u.RoleId == 2).Select(u => u.UserId).ToList();
            var carServiceOwnersIds = uniqueUserRoles.Where(u => u.RoleId == 3).Select(u => u.UserId).ToList();

            var SQL5 = $"--------------------< Total count: {totalCities} >--------------------{Environment.NewLine}INSERT INTO dbo.AspNetUserRoles{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastUserRole = uniqueUserRoles.Last();
            foreach (var item in uniqueUserRoles)
            {
                if (item.Equals(lastUserRole))
                {
                    SQL5 += $"('{item.UserId}',{item.RoleId});{Environment.NewLine}";
                }
                else
                {
                    SQL5 += $"('{item.UserId}',{item.RoleId}),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL5);

            #endregion USER ROLES

            #region CAR SERVICES

            var carService = new Faker<CarService>()
                .RuleFor(cs => cs.Name, f => f.Company.CompanyName())
                .RuleFor(cs => cs.Phone, f => f.Phone.PhoneNumber("(###) ###-####"))
                .RuleFor(cs => cs.Address, f => f.Address.StreetName())
                .RuleFor(cs => cs.Email, f => f.Internet.Email())
                .RuleFor(cs => cs.Website, (_, cs) => $"www.{cs.Name}.com")
                .RuleFor(cs => cs.CityId, f => f.Random.Int(1, totalCities))
                .RuleFor(cs => cs.OwnerId, f => f.PickRandom(carServiceOwnersIds));

            var generateCarServices = carService.Generate(150);
            var uniqueCarServicesByEmail = generateCarServices.DistinctBy(cs => cs.Email).ToList();
            var uniqueCarServices = uniqueCarServicesByEmail.DistinctBy(cs => cs.Name).ToList();
            var totalCarServices = uniqueCarServices.Count;

            var SQL6 = $"--------------------< Total count: {totalCarServices} >--------------------{Environment.NewLine}INSERT INTO dbo.CarServices{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastCarServices = uniqueCarServices.Last();
            foreach (var item in uniqueCarServices)
            {
                if (item.Equals(lastCarServices))
                {
                    SQL6 += $"('{item.Name.Replace("'", " ")}','{item.Phone}','{item.Address.Replace("'", " ")}', '{item.Email.Replace("'", "")}', '{item.Website.Replace("'", "")}','{item.CityId}','{item.OwnerId}');{Environment.NewLine}";
                }
                else
                {
                    SQL6 += $"('{item.Name.Replace("'", " ")}','{item.Phone}','{item.Address.Replace("'", " ")}', '{item.Email.Replace("'", "")}', '{item.Website.Replace("'", "")}','{item.CityId}','{item.OwnerId}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL6);

            #endregion CAR SERVICES

            #region MANUFACTURERS

            var manufacturer = new Faker<Manufacturer>()
                .RuleFor(m => m.Name, f => f.Company.CompanyName())
                .RuleFor(m => m.CountryId, f => f.Random.Int(1, totalCountries));

            var generateManufacturers = manufacturer.Generate(100);
            var uniqueManufacturers = generateManufacturers.DistinctBy(c => c.Name).ToList();
            var totalManufacturers = uniqueManufacturers.Count;

            var SQL7 = $"--------------------< Total count: {totalManufacturers} >--------------------{Environment.NewLine}INSERT INTO dbo.Manufacturers{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastManufacturer = uniqueManufacturers.Last();
            foreach (var item in uniqueManufacturers)
            {
                if (item.Equals(lastManufacturer))
                {
                    SQL7 += $"('{item.Name.Replace("'", " ")}','{item.CountryId}');{Environment.NewLine}";
                }
                else
                {
                    SQL7 += $"('{item.Name.Replace("'", " ")}','{item.CountryId}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL7);

            #endregion MANUFACTURERS

            #region FUEL TYPES

            var totalFuelTypes = 4;
            var SQL8 = $"--------------------< Total count: {totalFuelTypes} >--------------------{Environment.NewLine}" +
                       $"INSERT INTO dbo.FuelTypes{Environment.NewLine}" +
                       $"VALUES{Environment.NewLine}" +
                       $"('Diesel'),{Environment.NewLine}" +
                       $"('Petrol'),{Environment.NewLine}" +
                       $"('Petrol + LPG'),{Environment.NewLine}" +
                       $"('Hybrid');{Environment.NewLine}";

            File.AppendAllText("../SQL/SqlData.sql", SQL8);

            #endregion FUEL TYPES

            #region ENGINES

            var engine = new Faker<Engine>()
                .RuleFor(e => e.Name, f => f.Lorem.Word())
                .RuleFor(e => e.CubicCapacity, f => f.Random.Int(999, 3000))
                .RuleFor(e => e.Power, f => f.Random.Int(100, 700))
                .RuleFor(e => e.FuelTypeId, f => f.PickRandom(1, 2, 3, 4));

            var generateEngines = engine.Generate(100);
            var uniqueEngines = generateEngines.DistinctBy(e => e.Name).ToList();
            var totalEngines = uniqueEngines.Count;

            var SQL9 = $"--------------------< Total count: {totalEngines} >--------------------{Environment.NewLine}INSERT INTO dbo.Engines{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastEngine = uniqueEngines.Last();
            foreach (var item in uniqueEngines)
            {
                if (item.Equals(lastEngine))
                {
                    SQL9 += $"('{item.Name.Replace("'", " ")}','{item.CubicCapacity}', '{item.Power}', '{item.FuelTypeId}');{Environment.NewLine}";
                }
                else
                {
                    SQL9 += $"('{item.Name.Replace("'", " ")}','{item.CubicCapacity}', '{item.Power}', '{item.FuelTypeId}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL9);

            #endregion ENGINES

            #region MODELS

            var model = new Faker<CarModel>()
                .RuleFor(m => m.Name, f => f.Lorem.Word())
                .RuleFor(m => m.ManufacturerId, f => f.Random.Int(1, totalManufacturers))
                .RuleFor(m => m.EngineId, f => f.Random.Int(1, totalEngines));

            var generateModels = model.Generate(100);
            var uniqueModels = generateModels.DistinctBy(m => m.Name).ToList();
            var totalModels = uniqueModels.Count;

            var SQL10 = $"--------------------< Total count: {totalModels} >--------------------{Environment.NewLine}INSERT INTO dbo.CarModels{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastModel = uniqueModels.Last();
            foreach (var item in uniqueModels)
            {
                if (item.Equals(lastModel))
                {
                    SQL10 += $"('{item.Name.Replace("'", " ")}','{item.ManufacturerId}', '{item.EngineId}');{Environment.NewLine}";
                }
                else
                {
                    SQL10 += $"('{item.Name.Replace("'", " ")}','{item.ManufacturerId}', '{item.EngineId}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL10);

            #endregion MODELS

            #region CARS

            var car = new Faker<Car>()
                .RuleFor(c => c.Vin, f => f.Random.Int(1000000, 9999999).ToString())
                .RuleFor(c => c.FirstRegistration, f => f.Date.Past())
                .RuleFor(c => c.Mileage, f => f.Random.Int(0, 999999))
                .RuleFor(c => c.ModelId, f => f.Random.Int(1, totalRoles));

            var generateCars = car.Generate(carServiceOwnersIds.Count);
            var uniqueCars = generateCars.DistinctBy(c => c.Vin).ToList();
            var totalCars = uniqueCars.Count;

            var SQL11 = $"--------------------< Total count: {totalCars} >--------------------{Environment.NewLine}INSERT INTO dbo.Cars{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastCar = uniqueCars.Last();
            foreach (var item in uniqueCars)
            {
                if (item.Equals(lastCar))
                {
                    SQL11 += $"('{item.Vin}','{item.FirstRegistration.ToString("yyyy-MM-dd")}','{item.Mileage}','{item.ModelId}');{Environment.NewLine}";
                }
                else
                {
                    SQL11 += $"('{item.Vin}','{item.FirstRegistration.ToString("yyyy-MM-dd")}','{item.Mileage}','{item.ModelId}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL11);

            #endregion CARS

            #region USER CARS

            var userCar = new Faker<UserCar>()
                .RuleFor(uc => uc.CarId, f => f.Random.Int(1, totalCars))
                .RuleFor(uc => uc.UserId, f => f.Random.Int(1, totalUsers));

            var generateUserCars = userCar.Generate(totalUsers);
            var uniqueUserCars = generateUserCars.DistinctBy(u => u.UserId).ToList();
            var totalUserCars = uniqueUserCars.Count;

            var SQL12 = $"--------------------< Total count: {totalUserCars} >--------------------{Environment.NewLine}INSERT INTO dbo.UserCars{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastUserCar = uniqueUserCars.Last();
            foreach (var item in uniqueUserCars)
            {
                if (item.Equals(lastUserCar))
                {
                    SQL12 += $"('{item.UserId}','{item.CarId}');{Environment.NewLine}";
                }
                else
                {
                    SQL12 += $"('{item.UserId}','{item.CarId}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL12);

            #endregion USER CARS

            #region MAINTENANCE

            var maintenance = new Faker<Maintenance>()
                .RuleFor(m => m.Repairs, f => f.Lorem.Text())
                .RuleFor(m => m.Mileage, f => f.Random.Int(0, 999999))
                .RuleFor(m => m.RepairDate, f => f.Date.Past())
                .RuleFor(m => m.CarId, f => f.Random.Int(1, totalCars))
                .RuleFor(m => m.CarServiceId, f => f.Random.Int(1, totalCarServices));

            var generateMaintenance = maintenance.Generate(600);
            var totalMaintenances = generateMaintenance.Count;

            var SQL13 = $"--------------------< Total count: {totalMaintenances} >--------------------{Environment.NewLine}INSERT INTO dbo.Maintenance{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastMaintenance = generateMaintenance.Last();
            foreach (var item in generateMaintenance)
            {
                if (item.Equals(lastMaintenance))
                {
                    SQL13 += $"('{item.Repairs}','{item.Mileage}','{item.RepairDate.ToString("yyyy-MM-dd")}','{item.CarId}','{item.CarServiceId}');{Environment.NewLine}";
                }
                else
                {
                    SQL13 += $"('{item.Repairs}','{item.Mileage}','{item.RepairDate.ToString("yyyy-MM-dd")}','{item.CarId}','{item.CarServiceId}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL13);


            #endregion MAINTENANCE

            #region STATUS

            var totalStatuses = 5;
            var SQL14 = $"--------------------< Total count: {totalStatuses} >--------------------{Environment.NewLine}" +
                        $"INSERT INTO dbo.Status{Environment.NewLine}" +
                        $"VALUES{Environment.NewLine}" +
                        $"('Pending'),{Environment.NewLine}" +
                        $"('Accepted'),{Environment.NewLine}" +
                        $"('Repairing'),{Environment.NewLine}" +
                        $"('Ready for pick up'),{Environment.NewLine}" +
                        $"('Completed');{Environment.NewLine}";

            File.AppendAllText("../SQL/SqlData.sql", SQL14);

            #endregion STATUS

            #region SERVICE REQUEST

            var serviceRequest = new Faker<ServiceRequest>()
                .RuleFor(sr => sr.UserDescription, f => f.Lorem.Text())
                .RuleFor(sr => sr.Appointment, f => f.Date.Past())
                .RuleFor(sr => sr.RepairStart, f => f.Date.Past())
                .RuleFor(sr => sr.RepairEnd, f => f.Date.Future())
                .RuleFor(sr => sr.CarServiceId, f => f.Random.Int(1, totalCarServices))
                .RuleFor(sr => sr.UserId, f => f.PickRandom(carOwnersIds))
                .RuleFor(sr => sr.CarId, f => f.Random.Int(1, totalCars))
                .RuleFor(sr => sr.StatusId, f => f.Random.Int(1, totalStatuses));

            var generateServiceRequest = serviceRequest.Generate(200);
            var totalServicerequests = generateServiceRequest.Count;

            var SQL15 = $"--------------------< Total count: {totalServicerequests} >--------------------{Environment.NewLine}INSERT INTO dbo.ServiceRequest{Environment.NewLine}VALUES{Environment.NewLine}";

            var lastServiceRequest = generateServiceRequest.Last();
            foreach (var item in generateServiceRequest)
            {
                if (item.Equals(lastServiceRequest))
                {
                    SQL15 += $"('{item.UserDescription}','{item.Appointment?.ToString("yyyy-MM-dd")}','{item.RepairStart?.ToString("yyyy-MM-dd")}','{item.RepairEnd?.ToString("yyyy-MM-dd")}','{item.CarServiceId}','{item.UserId}','{item.CarId}','{item.StatusId}');{Environment.NewLine}";
                }
                else
                {
                    SQL15 += $"('{item.UserDescription}','{item.Appointment?.ToString("yyyy-MM-dd")}','{item.RepairStart?.ToString("yyyy-MM-dd")}','{item.RepairEnd?.ToString("yyyy-MM-dd")}','{item.CarServiceId}','{item.UserId}','{item.CarId}','{item.StatusId}'),{Environment.NewLine}";
                }
            }

            File.AppendAllText("../SQL/SqlData.sql", SQL15);

            #endregion SERVICE REQUEST
        }
    }
}