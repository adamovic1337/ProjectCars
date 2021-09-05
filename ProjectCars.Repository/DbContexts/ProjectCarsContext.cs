using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Configurations;

namespace ProjectCars.Repository.DbContexts
{
    public class ProjectCarsContext : IdentityDbContext<AppUser, AppRole, int>
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

        //This method should only be used when seeding database, connection string should be in appsettings.json
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =localhost; Initial Catalog = ProjectCars; Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarConfiguration).Assembly);
            //modelBuilder.SeedDatabaseWithFakeData();
            base.OnModelCreating(modelBuilder);
        }

        #endregion METHODS
    }
}