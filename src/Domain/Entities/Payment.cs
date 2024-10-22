using Domain.Enums;

namespace Domain.Entities;

public class Payment(double amount, PaymentMethod? method)
{
    public double Amount { get; set; } = amount;
    public PaymentMethod? Method { get; set; } = method;
}