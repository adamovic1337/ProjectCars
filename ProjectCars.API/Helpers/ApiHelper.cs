using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using ProjectCars.Repository;
using ProjectCars.Repository.Common;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.DbContexts;
using ProjectCars.Repository.Helpers;
using ProjectCars.Service;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Profiles;
using ProjectCars.Service.Validation;
using System.Linq;
using System.Text.Json;

namespace ProjectCars.API.Helpers
{
    public static class ApiHelper
    {
        #region STARTUP EXTENSIONS

        public static void AddDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(RoleProfile).Assembly);
            services.AddDbContext<ProjectCarsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProjectCars")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectCars.API", Version = "v1" });
            });
        }

        public static void AddFormaters(this IServiceCollection services)
        {
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
            })
            .AddXmlDataContractSerializerFormatters();
            services.Configure<MvcOptions>(config =>
            {
                var newtonsoftJsonOutputFormatter = config.OutputFormatters
                    .OfType<NewtonsoftJsonOutputFormatter>()
                    .FirstOrDefault();

                newtonsoftJsonOutputFormatter?.SupportedMediaTypes.Add("application/vnd.marvin.hateoas+json");
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
            services.AddScoped<ICarModelRepository, CarModelRepository>();
            services.AddScoped<ICarServiceRepository, CarServiceRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IEngineRepository, EngineRepository>();
            services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IServiceRequestRepository, ServiceRequestRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarRepository, CarRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IFuelTypeService, FuelTypeService>();
            services.AddScoped<IEngineService, EngineService>();
            services.AddScoped<ICarModelService, CarModelService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ICarServiceService, CarServiceService>();
            services.AddScoped<IServiceRequestService, ServiceRequestService>();
            services.AddScoped<ICarsService, CarsService>();
            services.AddScoped<IMaintenanceService, MaintenanceService>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateRoleValidator>();
            services.AddTransient<UpdateRoleValidator>();
            services.AddTransient<CreateCountryValidator>();
            services.AddTransient<UpdateCountryValidator>();
            services.AddTransient<CreateCityValidator>();
            services.AddTransient<UpdateCityValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<CreateManufacturerValidator>();
            services.AddTransient<UpdateManufacturerValidator>();
            services.AddTransient<CreateFuelTypeValidator>();
            services.AddTransient<UpdateFuelTypeValidator>();
            services.AddTransient<CreateEngineValidator>();
            services.AddTransient<UpdateEngineValidator>();
            services.AddTransient<CreateCarModelValidator>();
            services.AddTransient<UpdateCarModelValidator>();
            services.AddTransient<CreateStatusValidator>();
            services.AddTransient<UpdateStatusValidator>();
            services.AddTransient<CreateCarServiceValidator>();
            services.AddTransient<UpdateCarServiceValidator>();
            services.AddTransient<CreateServiceRequestValidator>();
            services.AddTransient<UpdateServiceRequestValidator>();
            services.AddTransient<CreateCarValidator>();
            services.AddTransient<UpdateCarValidator>();
            services.AddTransient<CreateMaintenanceValidator>();
            services.AddTransient<UpdateMaintenanceValidator>();
        }

        #endregion STARTUP EXTENSIONS

        #region HELPERS

        public static void PaginationMetadata<T>(this ControllerBase controllerBase, PaginationData<T> paginationData)
        {
            var paginationMetadata = new
            {
                totalCount = paginationData.TotalCount,
                pageSize = paginationData.PageSize,
                currentPage = paginationData.CurrentPage,
                totalPages = paginationData.TotalPages,
            };

            controllerBase.Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
        }

        #endregion HELPERS
    }
}