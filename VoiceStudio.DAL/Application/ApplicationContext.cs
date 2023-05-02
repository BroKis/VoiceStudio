
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VoiceSoundStudio.DAL.Configuration.ConnectionConfiguration;
using VoiceSoundStudio.DAL.Configuration.EntityConfigurations;
using VoiceSoundStudio.DAL.Models;

namespace VoiceSoundStudio.DAL.Application;

public class ApplicationContext:DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        :base(options)
    {
        
    }

    public ApplicationContext()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseMySql(ConnectionString.ConnectString(),
                    ServerVersion.AutoDetect(ConnectionString.ConnectString()))
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s),LogLevel.Trace);


        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        if (Database.IsRelational())
        {
            
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.Entity<Actor>().HasIndex(x => x.ActorStatusId).IsUnique(false);
            modelBuilder.ApplyConfiguration(new OrderToVoicingConfiguration());
            modelBuilder.Entity<OrderToVoicing>().HasIndex(x => x.StatusId).IsUnique(false);
            modelBuilder.Entity<OrderToVoicing>().HasIndex(x => x.TypeId).IsUnique(false);
            modelBuilder.ApplyConfiguration(new StudioConfiguration());
            modelBuilder.ApplyConfiguration(new TypesConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());

        }
        
        
       
    }
    
    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<OrderToVoicing> OrderVoicings{ get; set; } = null!;

    public DbSet<Studio> Studios{ get; set; } = null!;
    public DbSet<Types> Types{ get; set; } = null!;
    public DbSet<Status> Statuses { get; set; } = null;

    public DbSet<ActorStatus> ActorStatuses { get; set; } = null;
    
    public DbSet<OrderToVoicingActor> OrderToVoicingActors { get; set; }




}