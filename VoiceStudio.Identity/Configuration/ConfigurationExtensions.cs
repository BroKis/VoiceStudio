using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VoiceStudio.Identity.Application;
using VoiceStudio.Identity.Models;
using VoiceStudio.Identity.Service;

namespace VoiceStudio.Identity.Configuration;

public static class ConfigurationExtensions
{
    public static void ConfigureIdentity(this IServiceCollection services,string? connection)
    {

        services.AddDbContext<AuthDbContext>(option
            =>
        {
            option.UseMySql(connection, new MySqlServerVersion("8.0.32"));
        }).AddIdentity<ApplicationUser,ApplicationRole>(opt =>
        {
            opt.SignIn.RequireConfirmedAccount = false;
            opt.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<AuthDbContext>();


        services.AddScoped<IAccountService, AccountService>();



    }
}