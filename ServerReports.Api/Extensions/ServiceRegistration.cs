using ServerReports.Core.Interfaces;
using ServerReports.Core.Interfaces.IRepositories;
using ServerReports.Core.Interfaces.IServices;
using ServerReports.Core.Services;
using ServerReports.Infrastructure;
using ServerReports.Infrastructure.Repositories;

namespace ServerReports.Api.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IExportService, ExportService>();
        services.AddScoped<IExportRepository, ExportRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}