using Domain.Interfaces;

namespace Infrastructure.Services.Payments;

public class PayPalPaymentService : IPayment
{
    public string Pay(double amount)
    {
        return $"Processing PayPal payment with amount: {amount}";
    }
}