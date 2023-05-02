using VoiceStudio.Identity.Service;
using VoiceStudio.WebUI.UserService;

namespace VoiceStudio.WebUI;

public static class ConfigureService
{
    public static IServiceCollection AddMvcUIServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}