using Application.UseCases;
using CrossCutting.IoC;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UnitTests.UseCases;

public class ProcessPaymentUseCaseTest
{
    private IServiceProvider ServiceProvider { get; } = ConfigureServices();
    private ProcessPaymentUseCase UseCase { get; }

    public ProcessPaymentUseCaseTest()
    {
        UseCase = new ProcessPaymentUseCase(ServiceProvider);
    }

    [Theory]
    [InlineData(100.0, PaymentMethod.BankTransfer)]
    [InlineData(200.0, PaymentMethod.CreditCard)]
    [InlineData(300.0, PaymentMethod.DebitCard)]
    [InlineData(400.0, PaymentMethod.PayPal)]
    public void ShouldProcessPaymentWhenPaymentMethodIsSet(double amount, PaymentMethod method)
    {
        // Arrange
        var payment = new Payment(amount, method);

        var expectedMessage = method switch
        {
            PaymentMethod.BankTransfer => $"Processing bank transfer payment with amount: {amount:C}",
            PaymentMethod.CreditCard => $"Processing credit card payment with amount: {amount:C}",
            PaymentMethod.DebitCard => $"Processing debit card payment with amount: {amount:C}",
            PaymentMethod.PayPal => $"Processing PayPal payment with amount: {amount:C}",
            _ => throw new InvalidOperationException(
                "No service for type 'Domain.Interfaces.Factories.IPaymentFactory' has been registered.")
        };

        // Act
        var result = UseCase.Execute(payment);

        // Assert
        Assert.Equal(expectedMessage, result);
    }

    [Fact]
    public void ShouldThrowExceptionWhenPaymentMethodIsNotSet()
    {
        // Arrange
        var payment = new Payment(100.0, null);

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => UseCase.Execute(payment));
        Assert.Equal("No service for type 'Domain.Interfaces.Factories.IPaymentFactory' has been registered.",
            exception.Message);
    }

    [Fact]
    public void ShouldThrowExceptionWhenPaymentMethodIsInvalid()
    {
        // Arrange
        var invalidPaymentMethod = (PaymentMethod)999;
        var payment = new Payment(100.0, invalidPaymentMethod);

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => UseCase.Execute(payment));
        Assert.Equal("No service for type 'Domain.Interfaces.Factories.IPaymentFactory' has been registered.",
            exception.Message);
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddApplication();
        services.AddInfrastructure();

        return services.BuildServiceProvider();
    }
}