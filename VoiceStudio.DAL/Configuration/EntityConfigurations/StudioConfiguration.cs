using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoiceSoundStudio.DAL.Models;

namespace VoiceSoundStudio.DAL.Configuration.EntityConfigurations;

public class StudioConfiguration:IEntityTypeConfiguration<Studio>
{
    public void Configure(EntityTypeBuilder<Studio> builder)
    {
        builder.ToTable("Studio").HasKey(p => p.Id);
        builder.Property(p => p.Id);
        builder.Property(p => p.Title);
        builder.Property(p => p.Description);
        builder.Property(p => p.ImagePath);





    }
}