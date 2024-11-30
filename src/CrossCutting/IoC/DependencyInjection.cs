﻿using Application.Abstractions.UseCases;
using Application.UseCases;
using Domain.Interfaces.Factories;
using Infrastructure.Factories.Documents;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddFactories(services);
    }

    private static void AddFactories(IServiceCollection services)
    {
        services.AddScoped<IReportFactory, PdfReportFactory>();
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IGenerateReportUseCase, GenerateReportUseCase>();
    }
}