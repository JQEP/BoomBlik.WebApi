using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using BoomBlik.Infrastructure.Repository.Middleware;

namespace BoomBlik.Infrastructure.Repository;

public class BoomBlikDbContextFactory : IDesignTimeDbContextFactory<BoomBlikDbContext>
{
    private readonly DbContextOptionsBuilder<BoomBlikDbContext> _optionsBuilder = new();

    /// <summary>
    /// Used for migrations.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public BoomBlikDbContext CreateDbContext(string[] args)
    {
        var configuration = LoadConfiguration();
        var connectionString = configuration.GetSection("Infrastructure:Repository:ConnectionString").Value ??
                               throw new NullReferenceException("Given connectionstring was null");

        _optionsBuilder.UseSqlServer(connectionString);
        _optionsBuilder.AddInterceptors(new AuditingSaveChangesInterceptor());

        return new BoomBlikDbContext(_optionsBuilder.Options);
    }

    /// <summary>
    /// Used for services.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public BoomBlikDbContext CreateDbContext()
    {
        var configuration = LoadConfiguration();
        var connectionString = configuration.GetSection("Infrastructure:Repository:ConnectionString").Value ??
                               throw new NullReferenceException("Given connectionstring was null");

        _optionsBuilder.UseSqlServer(connectionString);
        _optionsBuilder.AddInterceptors(new AuditingSaveChangesInterceptor());
        return new BoomBlikDbContext(_optionsBuilder.Options);
    }

    /// <summary>
    /// Used for unit testing.
    /// </summary>
    /// <returns></returns>
    public BoomBlikDbContext CreateInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<BoomBlikDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .AddInterceptors(new AuditingSaveChangesInterceptor())
            .Options;

        return new BoomBlikDbContext(options);

        /*_optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        _optionsBuilder.AddInterceptors(new AuditingSaveChangesInterceptor());

        return new BoomBlikDbContext(_optionsBuilder.Options);*/
    }

    /// <summary>
    /// Load configuration from appsettings.json and environments.
    /// </summary>
    /// <returns></returns>
    private IConfiguration LoadConfiguration()
    {
        var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\BoomBlik.Application.WebApi"));

        return new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<BoomBlikDbContextFactory>()
            .Build();
    }
}
