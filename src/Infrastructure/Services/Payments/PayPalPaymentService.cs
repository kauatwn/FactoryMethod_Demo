using Domain.Interfaces.Services;

namespace Infrastructure.Services.Payments;

public class PayPalPaymentService : IPaymentService
{
    public string ProcessPayment(double amount)
    {
        return $"Processing PayPal payment with amount: {amount:C}";
    }
}