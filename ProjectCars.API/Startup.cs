using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using ProjectCars.API.Middleware;
using ProjectCars.Repository.Common;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.DbContexts;
using ProjectCars.Service;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Profiles;
using ProjectCars.Service.Validation;
using System.Linq;

namespace ProjectCars.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //formatters
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

            //auto mapper, context, swagger
            services.AddAutoMapper(typeof(RoleProfile).Assembly);
            services.AddDbContext<ProjectCarsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProjectCars")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectCars.API", Version = "v1" });
            });

            //repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services
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

            //validators
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectCars.API v1"));
            }

            app.UseRouting();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}