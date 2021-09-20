using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using ProjectCars.Model.Entities;
using ProjectCars.Repository;
using ProjectCars.Repository.Common;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.DbContexts;
using ProjectCars.Repository.Helpers;
using ProjectCars.Service;
using ProjectCars.Service.Contract;
using ProjectCars.Service.JWT;
using ProjectCars.Service.Profiles;
using ProjectCars.Service.Validation;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ProjectCars.API.Helpers
{
    public static class ApiExtensions
    {
        #region STARTUP EXTENSIONS

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

        public static void AddDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(RoleProfile).Assembly);
            services.AddDbContext<ProjectCarsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProjectCars")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectCars.API", Version = "v1" });
            });
        }

        public static void AddJwt(this IServiceCollection services, IConfiguration Configuration)
        {
            var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false
                };
            });
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<AppRole>()
                    .AddEntityFrameworkStores<ProjectCarsContext>();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            //});
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
            services.AddScoped<IAuthService, AuthService>();
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
            services.AddTransient<LoginValidator>();
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