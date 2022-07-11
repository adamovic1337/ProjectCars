using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Configurations;
using ProjectCars.Repository.Helpers;

namespace ProjectCars.Repository.DbContexts
{
    public class ProjectCarsContext : IdentityDbContext<AppUser, AppRole, int>
    {
        private readonly IConfiguration _configuration;

        #region CONSTRUCTORS

        public ProjectCarsContext()
        {
        }

        public ProjectCarsContext(DbContextOptions<ProjectCarsContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        #endregion CONSTRUCTORS

        #region TABLES

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
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
        //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProjectCars"));
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarConfiguration).Assembly);
            
            //modelBuilder.CreateScriptWithFakeData(); //Create script with fake data for dev purposes. Make "SQL" folder in root directory.

            base.OnModelCreating(modelBuilder);
        }

        #endregion METHODS
    }
}