using HerdManagement.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Data;
using Microsoft.EntityFrameworkCore;
using HerdManagement.Domain.SpecieBreed.Service;
using Applicattion.Services;
using HerdManagement.Domain.SpecieBreed.Repository;
using HerdManagement.Domain.Reproduction.Repository;

namespace UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AnimalDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("HERD_CATALOG"), options => options.MigrationsAssembly("UI")),ServiceLifetime.Transient);
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<ISpecieRepository,SpecieRepository>();
            services.AddTransient<IBreedRepository,BreedRepository>();
            services.AddTransient<IHerdRepository,HerdRepository>();
            services.AddTransient<IAnimalRepository,AnimalRepository>();
            services.AddTransient<ISpecieBreedService, SpecieBreedService>();
            services.AddTransient<IReproductionService, ReproductionService>();
            services.AddTransient<IReproductionRepository, ReproductionRepository>();
            services.AddScoped<BootstrapService, BootstrapService>();

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
