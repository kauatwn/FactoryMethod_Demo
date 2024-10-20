using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Infrastructure.Services.Payments;

namespace Infrastructure.Factories.Payments;

public class DebitCardPaymentFactory : IPaymentFactory
{
    public IPaymentService Create()
    {
        return new DebitCardPaymentService();
    }
}