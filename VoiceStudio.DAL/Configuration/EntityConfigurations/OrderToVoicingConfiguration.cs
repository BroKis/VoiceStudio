using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VoiceSoundStudio.DAL.Models;

namespace VoiceSoundStudio.DAL.Configuration.EntityConfigurations;

public class OrderToVoicingConfiguration:IEntityTypeConfiguration<OrderToVoicing>
{
    public void Configure(EntityTypeBuilder<OrderToVoicing> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);
        builder.Property(p => p.Title);
        builder.Property(p => p.Link);
        builder.Property(p => p.UserId);
        builder.Property(p => p.OrderDate);
        builder.HasOne(x => x.Studio).WithMany(x => x.FilmApplication)
            .HasForeignKey(x => x.StudioId);
        builder.HasOne(x => x.Type)
            .WithOne(x => x.Film).HasForeignKey<OrderToVoicing>(x => x.TypeId);
        builder.HasOne(x => x.Status).WithOne(x => x.Film)
            .HasForeignKey<OrderToVoicing>(x => x.StatusId);
        builder
            .HasMany(x => x.Actors)
            .WithMany(x => x.OrderVoicings)
            .UsingEntity<OrderToVoicingActor>(
                j => j
                    .HasOne(pt => pt.Actor)
                    .WithMany(t =>t.OrderToVoicingActors)
                    .HasForeignKey(x => x.ActorId),
                j=>j
                    .HasOne(pt =>pt.OrderToVoicing)
                    .WithMany(x => x.OrderToVoicingActors)
                    .HasForeignKey(x =>x.OrderVoicingId),
                j=>
                {
                    j.Property(x => x.ActorId);
                    j.Property(x => x.OrderVoicingId);
                    j.HasKey(t => new { OrderVoicingID = t.OrderVoicingId, ActorID = t.ActorId });
                    j.HasIndex(x => x.OrderVoicingId).IsUnique(false);
                    j.HasIndex(x => x.ActorId).IsUnique(false);

                }); 
        





    }
}