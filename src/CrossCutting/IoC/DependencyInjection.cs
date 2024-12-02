using Application.Abstractions.UseCases;
using Application.UseCases;
using Domain.Interfaces.Factories;
using Infrastructure.Factories.Reports;
using Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddFactories(services);
        AddOptions(services, configuration);
    }

    private static void AddFactories(IServiceCollection services)
    {
        services.AddScoped<IReportFactory, PdfReportFactory>();
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IGenerateReportUseCase, GenerateReportUseCase>();
    }

    private static void AddOptions(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ReportOptions>(configuration.GetSection(ReportOptions.Key));
    }
}