using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoiceSoundStudio.DAL.Models;

namespace VoiceSoundStudio.DAL.Configuration.EntityConfigurations;

public class StatusConfiguration:IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);
        builder.Property(x => x.Desc);
        
    }
}