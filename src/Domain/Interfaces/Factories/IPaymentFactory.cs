using Domain.Interfaces.Services;

namespace Domain.Interfaces.Factories;

public interface IPaymentFactory
{
    IPaymentService Create();
}