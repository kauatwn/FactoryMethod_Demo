using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Infrastructure.Services.Payments;

namespace Infrastructure.Factories.Payments;

public class CreditCardPaymentFactory : IPaymentFactory
{
    public IPaymentService Create()
    {
        return new CreditCardPaymentService();
    }
}