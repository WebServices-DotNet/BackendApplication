using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CarFleetManager.Models;
using CarFleetManager.Repository;
using CarFleetManager.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CarFleetManager
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
            
            services.Configure<CarFleetDatabaseSettings>(
                Configuration.GetSection(nameof(CarFleetDatabaseSettings)));

            services.AddSingleton<ICarFleetDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CarFleetDatabaseSettings>>().Value);

            services.AddScoped(typeof(IMongoRepository<Car>), typeof(MongoRepository<Car>));
            services.AddSingleton<CarService>();
            
            services.AddScoped(typeof(IMongoRepository<Accel>), typeof(MongoRepository<Accel>));
            services.AddSingleton<AccelService>();
            
            services.AddScoped(typeof(IMongoRepository<Speed>), typeof(MongoRepository<Speed>));
            services.AddSingleton<SpeedService>();
            
            services.AddScoped(typeof(IMongoRepository<Temperature>), typeof(MongoRepository<Temperature>));
            services.AddSingleton<TemperatureService>();
            
            services.AddScoped(typeof(IMongoRepository<EngineSpeed>), typeof(MongoRepository<EngineSpeed>));
            services.AddSingleton<EngineService>();
            
            services.AddSingleton<DataService>();

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarFleetManager", Version = "v1" });
            });


            services.AddHostedService<RabbitReceiver>();

            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarFleetManager v1"));
            // }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();

            });
        }
    }
}
