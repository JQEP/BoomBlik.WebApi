using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BoomBlik.Core.Domain.Services;
using BoomBlik.Core.Infrastructure.Services;
using BoomBlik.Modules.Reports.Services;

namespace BoomBlik.Modules.Reports;

public static class ReportsModule
{
    public static IServiceCollection RegisterReportsModule(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.AddScoped<ICustomerAddressService, CustomerAddressService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ITreeService, TreeService>();
        services.AddScoped<ITreeReportPdfService, TreeReportPdfService>();
        services.AddScoped<ITreeReportService, TreeReportService>();
        services.AddScoped<ITreeReportPictureService, TreeReportPictureService>();
        services.AddScoped<IPdfService, PdfService>();
        return services;
    }
}