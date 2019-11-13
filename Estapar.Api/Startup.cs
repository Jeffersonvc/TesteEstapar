using AutoMapper;
using Estapar.Api.Helper;
using Estapar.Api.Mapping;
using Estapar.Api.Repository;
using Estapar.Api.Repository.Interfaces;
using Estapar.Api.Service;
using Estapar.Api.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Estapar.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var config = MapperConfig.ConfigMapper();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            RegisterSevices(ref services);
        }

        public void RegisterSevices(ref IServiceCollection services)
        {
            services.AddTransient<IValetParkingRepository, ValetParkingRepository>();

            services.AddTransient<IVehicleBrandRepository, VehicleBrandRepository>();
            services.AddTransient<IVehicleBrandService, VehicleBrandService>();

            services.AddTransient<IVehicleModelRepository, VehicleModelRepository>();
            services.AddTransient<IVehicleModelService, VehicleModelService>();

            services.AddTransient<IValetParkingRepository, ValetParkingRepository>();
            services.AddTransient<IValetParkingService, ValetParkingService>();

            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IVehicleService, VehicleService>();

            services.AddTransient<IValetParkingVehicleRepository, ValetParkingVehicleRepository>();
            services.AddTransient<IValetParkingVehicleService, ValetParkingVehicleService>();

            services.AddTransient<IValetParkingVehicleDetailRepository, ValetParkingVehicleDetailRepository>();
            services.AddTransient<IValetParkingVehicleDetailService, ValetParkingVehicleDetailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
