namespace Domain.Interfaces.Services;

public interface IPaymentService
{
    string ProcessPayment(double amount);
}