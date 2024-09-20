using Domain.Interfaces.Services;

namespace Infrastructure.Services.Payments;

public class CreditCardPaymentService : IPaymentService
{
    public string Pay(double amount)
    {
        return $"Processing credit card payment with amount: {amount}";
    }
}