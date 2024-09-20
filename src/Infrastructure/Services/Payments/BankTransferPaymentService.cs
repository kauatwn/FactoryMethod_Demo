using Domain.Interfaces;

namespace Infrastructure.Services.Payments;

public class BankTransferPaymentService : IPayment
{
    public string Pay(double amount)
    {
        return $"Processing bank transfer payment with amount: {amount}";
    }
}