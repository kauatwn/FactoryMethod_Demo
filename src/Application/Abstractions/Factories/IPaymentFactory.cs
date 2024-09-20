using Domain.Interfaces.Services;

namespace Application.Abstractions.Factories;

public interface IPaymentFactory
{
    IPaymentService Create();
}