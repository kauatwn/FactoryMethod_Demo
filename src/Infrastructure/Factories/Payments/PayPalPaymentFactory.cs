using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Infrastructure.Services.Payments;

namespace Infrastructure.Factories.Payments;

public class PayPalPaymentFactory : IPaymentFactory
{
    public IPaymentService Create()
    {
        return new PayPalPaymentService();
    }
}