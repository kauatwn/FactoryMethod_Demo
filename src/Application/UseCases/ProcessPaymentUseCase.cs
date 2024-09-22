using Application.Abstractions.UseCases;
using Domain.Entities;
using Domain.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases;

public class ProcessPaymentUseCase(IServiceProvider serviceProvider) : IProcessPaymentUseCase
{
    private IServiceProvider ServiceProvider { get; } = serviceProvider;

    public string Execute(Payment payment)
    {
        var factory = ServiceProvider.GetRequiredKeyedService<IPaymentFactory>(payment.Method);
        var paymentService = factory.Create();

        return paymentService.Pay(payment.Amount);
    }
}