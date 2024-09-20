using Application.Abstractions.Factories;
using Domain.Interfaces;

namespace Infrastructure.Factories.Payments.Base;

public abstract class PaymentFactory : IPaymentFactory
{
    public abstract IPayment Create();
}