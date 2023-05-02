using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VoiceSoundStudio.DAL.Models;

namespace VoiceSoundStudio.DAL.Configuration.EntityConfigurations;

public class ActorConfiguration:IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);
        builder.Property(p => p.Fio);
        builder.Property(p => p.Biography);
        builder.Property(p => p.BirthDate);
        builder.Property(p => p.Voice);
        builder.Property(p => p.ImagePath);
        
        builder.HasOne(x => x.Studio).WithMany(x => x.Actors).HasForeignKey(x => x.StudioId);
        builder.HasOne(x => x.ActorStatus).WithOne(x => x.Actor).HasForeignKey<Actor>(x => x.ActorStatusId);

        ModelBuilder modbuilder = new ModelBuilder();
        modbuilder.Entity<Actor>().HasIndex(x => x.ActorStatusId).IsUnique(false);








    }
}