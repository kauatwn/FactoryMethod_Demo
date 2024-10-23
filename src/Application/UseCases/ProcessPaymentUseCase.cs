using Application.Abstractions.UseCases;
using Domain.Entities;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases;

public class ProcessPaymentUseCase(IServiceProvider serviceProvider) : IProcessPaymentUseCase
{
    private IServiceProvider ServiceProvider { get; } = serviceProvider;
    public IPaymentService PaymentService { get; private set; } = default!;

    public string Execute(Payment payment)
    {
        var factory = ServiceProvider.GetRequiredKeyedService<IPaymentFactory>(payment.Method);
        PaymentService = factory.Create();

        return PaymentService.ProcessPayment(payment.Amount);
    }
}