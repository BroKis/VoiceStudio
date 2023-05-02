using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VoiceSoundStudio.DAL.Models;

namespace VoiceSoundStudio.DAL.Configuration.EntityConfigurations;

public class TypesConfiguration:IEntityTypeConfiguration<Types>
{
    public void Configure(EntityTypeBuilder<Types> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);
        builder.Property(p => p.Type);


    }
}