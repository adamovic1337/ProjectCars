﻿using Microsoft.EntityFrameworkCore;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Configurations;
using ProjectCars.Repository.Helpers;

namespace ProjectCars.Repository.DbContexts
{
    public class ProjectCarsContext : DbContext
    {
        #region CONSTRUCTORS

        public ProjectCarsContext()
        {
        }

        public ProjectCarsContext(DbContextOptions<ProjectCarsContext> options)
            : base(options)
        {
        }

        #endregion CONSTRUCTORS

        #region TABLES

        public DbSet<Role> Roles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }

        #endregion TABLES

        #region METHODS

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //This method should only be used when seeding database, connection string should be in appsettings.json 
        //    optionsBuilder.UseSqlServer(@"Data Source =.\SQLEXPRESS; Initial Catalog = ProjectCars; Integrated Security = True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarConfiguration).Assembly);
            modelBuilder.SeedDatabaseWithFakeData();
        }

        #endregion METHODS
    }
}