using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Infrastructure.Services.Payments;

namespace Infrastructure.Factories.Payments;

public class BankTransferPaymentFactory : IPaymentFactory
{
    public IPaymentService Create()
    {
        return new BankTransferPaymentService();
    }
}