using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;

namespace Infrastructure.Factories.Payments.Base;

public abstract class PaymentFactory : IPaymentFactory
{
    public abstract IPaymentService Create();
}