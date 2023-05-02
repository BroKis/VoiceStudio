using Microsoft.AspNetCore.Identity;

namespace VoiceStudio.Identity.Models;

public class ApplicationUser:IdentityUser<int>
{
    public string Name { get; set; }
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}