using Application.UseCases;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Application.UnitTests.UseCases;

public class ProcessPaymentUseCaseTest
{
    private Mock<IKeyedServiceProvider> KeyedServiceProviderMock { get; } = new();
    private Mock<IPaymentFactory> PaymentFactoryMock { get; } = new();
    private Mock<IPaymentService> PaymentServiceMock { get; } = new();
    private ProcessPaymentUseCase UseCase { get; }

    public ProcessPaymentUseCaseTest()
    {
        UseCase = new ProcessPaymentUseCase(KeyedServiceProviderMock.Object);
    }
    
    [Fact]
    public void ShouldProcessPaymentWhenPaymentMethodIsSet()
    {
        // Arrange
        var payment = new Payment(100.0, PaymentMethod.BankTransfer);

        KeyedServiceProviderMock.Setup(ksp =>
                ksp.GetRequiredKeyedService(typeof(IPaymentFactory), It.IsAny<PaymentMethod>()))
            .Returns(PaymentFactoryMock.Object);

        PaymentFactoryMock.Setup(f => f.Create()).Returns(PaymentServiceMock.Object);

        // Act
        UseCase.Execute(payment);

        // Assert
        Assert.NotNull(UseCase.PaymentService);

        KeyedServiceProviderMock.Verify(
            ksp => ksp.GetRequiredKeyedService(typeof(IPaymentFactory), It.IsAny<PaymentMethod>()),
            Times.Once);

        PaymentFactoryMock.Verify(f => f.Create(), Times.Once);
        PaymentServiceMock.Verify(s => s.ProcessPayment(It.IsAny<double>()), Times.Once);
    }
    
    [Fact]
    public void ShouldThrowExceptionWhenPaymentMethodIsNotProvidedAndSet()
    {
        // Arrange
        var payment = new Payment(100.0, null);

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => UseCase.Execute(payment));
        Assert.Equal("Payment method is not set", exception.Message);
    }
}