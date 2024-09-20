using Domain.Interfaces;
using Infrastructure.Factories.Payments.Base;
using Infrastructure.Services.Payments;

namespace Infrastructure.Factories.Payments;

public class CreditCardPaymentFactory : PaymentFactory
{
    public override IPayment Create()
    {
        return new CreditCardPaymentService();
    }
}