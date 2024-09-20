using Domain.Interfaces;

namespace Infrastructure.Services.Payments;

public class CreditCardPaymentService : IPayment
{
    public string Pay(double amount)
    {
        return $"Processing credit card payment with amount: {amount}";
    }
}