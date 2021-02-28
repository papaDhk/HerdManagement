using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using HerdManagement.Domain.Common.Repositories;
using HerdManagement.Domain.SpecieBreed.Repository;
using HerdManagement.Domain.SpecieBreed.Service;
using HerdManagement.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App
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
            
            services.AddDbContext<HerdManagementDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("HERD_CATALOG"), options => options.MigrationsAssembly("Web"))
                , ServiceLifetime.Singleton
            );
            services.AddControllers();
            services.AddSingleton<IHerdRepository, HerdRepositoryEF>();
            services.AddSingleton<ISpecieRepository, SpecieRepository>();
            services.AddTransient<IBreedRepository, BreedRepository>();
            services.AddSingleton<ISpecieBreedService, SpecieBreedService>();
            services.AddSingleton<IMeasurementUnitRepository, MeasurementUnitRepositoryEF>();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin();
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
