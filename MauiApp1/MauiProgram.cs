using System.Reflection;
using Applicattion.Services;
using HerdManagement.Domain.Characteristic.Repositories;
using HerdManagement.Domain.Common.Repositories;
using HerdManagement.Domain.Feeding.Repository;
using HerdManagement.Domain.Reproduction.Repository;
using HerdManagement.Domain.SpecieBreed.Repository;
using HerdManagement.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SharedComponents.Utils;
using Syncfusion.Blazor;

namespace MauiApp1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
        
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("MauiApp1.appsettings.json");

        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();


        builder.Configuration.AddConfiguration(config);

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddDbContext<HerdManagementDbContext>(options =>
                options.UseSqlServer("Server=localhost,1433;Database=HerdManagement2;User Id=sa;Password=Azerty12345;Max Pool Size=1000;", options => options.MigrationsAssembly("MauiApp1"))
            , ServiceLifetime.Transient
        );


        builder.Services.AddTransient<ISpecieRepository, SpecieRepository>();
        builder.Services.AddTransient<IBreedRepository, BreedRepository>();
        builder.Services.AddTransient<IHerdRepository, HerdRepositoryEF>();
        builder.Services.AddTransient<IAnimalRepository, AnimalRepositoryEF>();
        builder.Services.AddTransient<ISpecieBreedService, SpecieBreedService>();
        builder.Services.AddTransient<IReproductionService, ReproductionService>();
        builder.Services.AddTransient<IReproductionRepository, ReproductionRepositoryEF>();
        builder.Services.AddTransient<IMeasurementUnitRepository, MeasurementUnitRepositoryEf>();
        builder.Services.AddTransient<IFoodRepository, FoodRepositoryEf>();
        builder.Services.AddTransient<IWeighingRepository, WeighingRepositoryEF>();
        builder.Services.AddScoped<BootstrapService, BootstrapService>();
        builder.Services.AddTransient<ICharacteristicRepository, CharacteristicRepository>();
        builder.Services.AddTransient<IAnimalFeedingRepository, AnimalFeedingRepositoryEF>();
        builder.Services.AddTransient<IFoodRepository, FoodRepositoryEf>();
        builder.Services.AddSyncfusionBlazor();

        return builder.Build();
    }
}