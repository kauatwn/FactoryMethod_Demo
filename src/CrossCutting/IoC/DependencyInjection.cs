using Application.Abstractions.UseCases;
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
        services.AddScoped<IDocumentFactory, PdfDocumentFactory>();

        // O Factory Method Pattern não permite alterar o tipo de objeto criado em tempo de execução.
        // Para alternar entre diferentes tipos de objetos, seria necessário modificar a configuração do DI,
        // o que exigiria uma reinicialização da aplicação. Para uma troca dinâmica em tempo de execução,
        // é recomendado usar o Strategy Pattern.
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IPrintDocumentUseCase, PrintDocumentUseCase>();
    }
}