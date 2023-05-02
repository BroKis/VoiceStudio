using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VoiceSoundStudio.DAL.Application;
using VoiceSoundStudio.DAL.Models;
using VoiceSoundStudio.DAL.Repository.Interfaces;
using VoiceSoundStudio.DAL.Repository.RepositoryRealisation;


namespace VoiceStudio.Configuration.DALConfiguration;

public static class ConfigurationExtensions
{
    public static void ConfigureDAL(this IServiceCollection services,string? connection)
    {

        services.AddDbContext<ApplicationContext>(option
            =>
        {
            option.UseMySql(connection, new MySqlServerVersion("8.0.32"));
        });
        
        
        services.AddScoped<IOrderToVoicicngRepository, OrderToVoicicngRepository>();
        services.AddScoped<IStudioRepository, StudioRepository>();
        services.AddScoped<ITypesRepository, TypesRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<IActorStatusRepository, ActorStatusRepository>();
        services.AddScoped<IActorRepository, ActorRepository>();
       


    }
    
}