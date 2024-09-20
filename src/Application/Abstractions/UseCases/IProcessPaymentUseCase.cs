using Domain.Entities;

namespace Application.Abstractions.UseCases;

public interface IProcessPaymentUseCase
{
    string Execute(Payment payment);
}