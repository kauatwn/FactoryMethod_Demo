using Application.Abstractions.UseCases;
using Application.UseCases;
using Domain.Enums;
using Domain.Interfaces.Factories;
using Infrastructure.Factories.Payments;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddFactories(services);
        AddUseCases(services);
    }

    private static void AddFactories(IServiceCollection services)
    {
        services.AddKeyedSingleton<IPaymentFactory, BankTransferPaymentFactory>(PaymentMethod.BankTransfer);
        services.AddKeyedSingleton<IPaymentFactory, CreditCardPaymentFactory>(PaymentMethod.CreditCard);
        services.AddKeyedSingleton<IPaymentFactory, DebitCardPaymentFactory>(PaymentMethod.DebitCard);
        services.AddKeyedSingleton<IPaymentFactory, PayPalPaymentFactory>(PaymentMethod.PayPal);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IProcessPaymentUseCase, ProcessPaymentUseCase>();
    }
}