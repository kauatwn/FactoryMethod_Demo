using Application.Abstractions.UseCases;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Factories;

namespace Application.UseCases;

public class ProcessPaymentUseCase(IPaymentFactory creditCardFactory, IPaymentFactory debitCardFactory)
    : IProcessPaymentUseCase
{
    private IPaymentFactory CreditCardFactory { get; } = creditCardFactory;
    private IPaymentFactory DebitCardFactory { get; } = debitCardFactory;

    public string Execute(Payment payment)
    {
        if (payment.Method == null)
        {
            throw new InvalidOperationException("Payment method is not set.");
        }

        var factory = payment.Method switch
        {
            PaymentMethod.CreditCard => CreditCardFactory,
            PaymentMethod.DebitCard => DebitCardFactory,
            _ => throw new InvalidOperationException("Invalid payment method.")
        };

        var paymentService = factory.Create();

        return paymentService.ProcessPayment(payment.Amount);
    }
}