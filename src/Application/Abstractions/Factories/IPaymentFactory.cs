using Domain.Interfaces;

namespace Application.Abstractions.Factories;

public interface IPaymentFactory
{
    IPayment Create();
}