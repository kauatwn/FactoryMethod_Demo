using Application.Abstractions.Factories;
using Application.Abstractions.UseCases;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases;

public class ProcessPaymentUseCase(IServiceProvider serviceProvider) : IProcessPaymentUseCase
{
    private IServiceProvider ServiceProvider { get; } = serviceProvider;

    public string Execute(Payment payment)
    {
        var factory = ServiceProvider.GetRequiredKeyedService<IPaymentFactory>(payment.Method);

        var process = factory.Create();
        return process.Pay(payment.Amount);
    }
}