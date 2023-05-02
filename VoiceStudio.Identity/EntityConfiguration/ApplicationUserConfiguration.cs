using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoiceStudio.Identity.Models;

namespace VoiceStudio.Identity.EntityConfiguration;

public class ApplicationUserConfiguration:IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.Name);

        builder.HasMany(e => e.UserRoles).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired();
    }
}