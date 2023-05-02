using Microsoft.Extensions.DependencyInjection;
using Sound_VoiceStudio.BLL.Infrastructure.ProfilesForMapper;
using Sound_VoiceStudio.BLL.Interfaces;
using Sound_VoiceStudio.BLL.Services;

using VoiceStudio.Configuration.DALConfiguration;


namespace Sound_VoiceStudio.BLL.Infrastructure.Configuration;

public static class ConfigurationExtensions
{
    public static void ConfigureBLL(this IServiceCollection services,string? connection)
    {
        services.ConfigureDAL(connection);
        
        services.AddAutoMapper(
            typeof(ActorProfile),
            typeof(FilmApplicationProfile),
            typeof(StudioProfile),
            typeof(TypesProfile),
            typeof(StudioProfile),
            typeof(ActorStatusProfile));
            services.AddScoped<IActorService, ActorService>();
        services.AddScoped<IOrderToVoicingService, OrderToVoicingService>();
        services.AddScoped<IStudioService,StudioService>();
        services.AddScoped<ITypesService,TypesService>();
        services.AddScoped<IStatusService, StatusService>();
        services.AddScoped<IActorStatusService, ActorStatusService>();
       

    }
}