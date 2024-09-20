using Domain.Interfaces.Services;
using Infrastructure.Factories.Payments.Base;
using Infrastructure.Services.Payments;

namespace Infrastructure.Factories.Payments;

public class PayPalPaymentFactory : PaymentFactory
{
    public override IPaymentService Create()
    {
        return new PayPalPaymentService();
    }
}