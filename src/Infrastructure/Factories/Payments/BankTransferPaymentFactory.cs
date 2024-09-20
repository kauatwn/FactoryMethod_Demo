﻿using Domain.Interfaces;
using Infrastructure.Factories.Payments.Base;
using Infrastructure.Services.Payments;

namespace Infrastructure.Factories.Payments;

public class BankTransferPaymentFactory : PaymentFactory
{
    public override IPayment Create()
    {
        return new BankTransferPaymentService();
    }
}