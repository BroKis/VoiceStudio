using VoiceStudio.Identity.Models;
using VoiceStudio.Identity.Utils;

namespace VoiceStudio.Identity.Service;

public interface IAccountService
{
    Task<Response<bool>> RegisterAsync(ApplicationUser user, string password,string role);

    Task<Response<bool>> LoginAsync(string email, string password);

    Task<Response<bool>> LogoutAsync();

    
}