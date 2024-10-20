using Domain.Interfaces.Services;

namespace Infrastructure.Services.Payments;

public class DebitCardPaymentService : IPaymentService
{
    public string ProcessPayment(double amount)
    {
        return $"Processing debit card payment with amount: {amount:C}";
    }
}