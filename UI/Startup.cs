using System;
using Applicattion.Services;
using HerdManagement.Domain.Characteristic.Repositories;
using HerdManagement.Domain.Reproduction.Repository;
using HerdManagement.Domain.SpecieBreed.Repository;
using HerdManagement.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using HerdManagement.Domain.Common.Repositories;
using HerdManagement.Domain.Feeding.Repository;
using SharedComponents.Utils;

namespace UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "herdDataBase.db");
        }

        public string DbPath { get; set; }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HerdManagementDbContext>(options =>
                options.UseSqlite($"Data Source={DbPath}", options => options.MigrationsAssembly("UI"))
                , ServiceLifetime.Transient
            );

            
            
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<ISpecieRepository, SpecieRepositoryEF>();
            services.AddTransient<IBreedRepository, BreedRepositoryEf>();
            services.AddTransient<IHerdRepository, HerdRepositoryEF>();
            services.AddTransient<IAnimalRepository, AnimalRepositoryEF>();
            services.AddTransient<ISpecieBreedService, SpecieBreedService>();
            services.AddTransient<IReproductionService, ReproductionService>();
            services.AddTransient<IReproductionRepository, ReproductionRepositoryEF>();
            services.AddTransient<IMeasurementUnitRepository, MeasurementUnitRepositoryEf>();
            services.AddTransient<IFoodRepository, FoodRepositoryEf>();
            services.AddTransient<IWeighingRepository, WeighingRepositoryEF>();
            services.AddScoped<BootstrapService, BootstrapService>();
            services.AddTransient<ICharacteristicRepository, CharacteristicRepository>();
            services.AddTransient<IAnimalFeedingRepository, AnimalFeedingRepositoryEF>();
            services.AddTransient<IFoodRepository, FoodRepositoryEf>();
            services.AddSyncfusionBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU0OTEwQDMxMzgyZTMzMmUzMGc5bnFJc2VtTmhBbStaSFpWbVR2aHFoeTY1bFFUaDZkUG0rN2xIMEdKZFU9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
