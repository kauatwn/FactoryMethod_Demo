using Domain.Interfaces.Services;

namespace Infrastructure.Services.Payments;

public class BankTransferPaymentService : IPaymentService
{
    public string ProcessPayment(double amount)
    {
        return $"Processing bank transfer payment with amount: {amount:C}";
    }
}