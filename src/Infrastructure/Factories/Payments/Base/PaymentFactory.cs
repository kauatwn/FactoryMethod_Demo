using Application.Abstractions.Factories;
using Domain.Interfaces;
using Domain.Interfaces.Services;

namespace Infrastructure.Factories.Payments.Base;

public abstract class PaymentFactory : IPaymentFactory
{
    public abstract IPaymentService Create();
}