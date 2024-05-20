using BoomBlik.Infrastructure.Repository.Configuration;
using BoomBlik.Infrastructure.Repository.Mappers;
using BoomBlik.Infrastructure.Repository.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BoomBlik.Infrastructure.Repository;

/// <summary>
/// The module for the repository.
/// </summary>
public static class SetupInfrastructureRepository
{
    public static IServiceCollection RegisterInfrastructureRepository(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.RegisterDatabase(configuration);
        services.RegisterMappers();

        return services;
    }

    private static void RegisterDatabase(this IServiceCollection services, IConfigurationRoot configuration)
    {
        var repositoryConfiguration = configuration.GetSection("Infrastructure:Repository").Get<RepositoryModuleConfiguration>()!;
        services.AddSingleton(repositoryConfiguration);

        services.AddDbContextFactory<BoomBlikDbContext>(options => options.UseSqlServer(repositoryConfiguration.ConnectionString)
            .AddInterceptors(new AuditingSaveChangesInterceptor()));
        services.AddSingleton<BoomBlikDbContextFactory>();
    }

    private static void RegisterMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CustomerAddressMapper), typeof(CustomerMapper), typeof(ProjectMapper), typeof(TreeMapper),
            typeof(TreeReportMapper), typeof(TreeReportPdfMapper), typeof(TreeReportPictureMapper));
    }
}