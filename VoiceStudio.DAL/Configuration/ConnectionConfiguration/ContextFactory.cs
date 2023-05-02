using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using VoiceSoundStudio.DAL.Application;

namespace VoiceStudio.Configuration.ConnectionConfiguration;

public class ContextFactory:IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder();
        // установка пути к текущему каталогу
        builder.SetBasePath(Directory.GetCurrentDirectory());
        // получаем конфигурацию из файла appsettings.json
        builder.AddJsonFile("appsettings.json");
        var config = builder.Build();
        // получаем строку подключения
        string connectionString
            = config.GetConnectionString("DefaultConnection");
        var optionsBuilder =
            new DbContextOptionsBuilder<ApplicationContext>();
        var seviceVersion = new MySqlServerVersion(new Version(8, 0, 32));
        DbContextOptions<ApplicationContext> options
            = optionsBuilder
                .UseMySql(connectionString,seviceVersion).Options;
        return new ApplicationContext(optionsBuilder.Options);


    }
}