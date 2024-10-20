using Domain.Interfaces.Services;

namespace Infrastructure.Services.Payments;

public class CreditCardPaymentService : IPaymentService
{
    public string ProcessPayment(double amount)
    {
        return $"Processing credit card payment with amount: {amount:C}";
    }
}