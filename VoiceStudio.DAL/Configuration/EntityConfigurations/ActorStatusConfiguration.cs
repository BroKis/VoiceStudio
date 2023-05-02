using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoiceSoundStudio.DAL.Models;

namespace VoiceSoundStudio.DAL.Configuration.EntityConfigurations;

public class ActorStatusConfiguration:IEntityTypeConfiguration<ActorStatus>
{
    public void Configure(EntityTypeBuilder<ActorStatus> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);
        builder.Property(x => x.Desc);
        
    }
}