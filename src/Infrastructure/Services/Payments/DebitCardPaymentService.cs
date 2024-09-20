using Domain.Interfaces;

namespace Infrastructure.Services.Payments;

public class DebitCardPaymentService : IPayment
{
    public string Pay(double amount)
    {
        return $"Processing debit card payment with amount: {amount}";
    }
}