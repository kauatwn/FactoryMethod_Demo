using Domain.Enums;

namespace Domain.Entities;

public class Payment
{
    public double Amount { get; set; }
    public PaymentMethod Method { get; set; }
}