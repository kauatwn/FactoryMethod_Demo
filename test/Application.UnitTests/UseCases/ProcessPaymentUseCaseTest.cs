using Application.UseCases;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Moq;

namespace Application.UnitTests.UseCases;

public class ProcessPaymentUseCaseTest
{
    private Mock<IPaymentFactory> CreditCardPaymentMock { get; } = new();
    private Mock<IPaymentFactory> DebitCardPaymentMock { get; } = new();
    private Mock<IPaymentService> PaymentServiceMock { get; } = new();
    private ProcessPaymentUseCase UseCase { get; }

    public ProcessPaymentUseCaseTest()
    {
        UseCase = new ProcessPaymentUseCase(CreditCardPaymentMock.Object, DebitCardPaymentMock.Object);
    }

    [Fact]
    public void ShouldProcessPaymentWhenPaymentMethodIsSet()
    {
        // Arrange
        var payment = new Payment(100.0, PaymentMethod.CreditCard);
        const string expectedMessage = "Payment processed successfully.";

        CreditCardPaymentMock.Setup(f => f.Create()).Returns(PaymentServiceMock.Object);

        PaymentServiceMock.Setup(s => s.ProcessPayment(It.IsAny<double>())).Returns(expectedMessage);

        // Act
        var result = UseCase.Execute(payment);

        // Assert
        Assert.Equal(expectedMessage, result);

        CreditCardPaymentMock.Verify(f => f.Create(), Times.Once);
        PaymentServiceMock.Verify(s => s.ProcessPayment(It.IsAny<double>()), Times.Once);
    }

    [Fact]
    public void ShouldThrowExceptionWhenPaymentMethodIsNotSet()
    {
        // Arrange
        var payment = new Payment(100.0, null);

        // Act
        Action act = () => UseCase.Execute(payment);

        // Assert
        var exception = Assert.Throws<InvalidOperationException>(act);
        Assert.Equal("Payment method is not set.", exception.Message);
    }

    [Fact]
    public void ShouldThrowExceptionWhenPaymentMethodIsInvalid()
    {
        // Arrange
        var payment = new Payment(100.0, (PaymentMethod)999);

        // Act
        Action act = () => UseCase.Execute(payment);

        // Assert
        var exception = Assert.Throws<InvalidOperationException>(act);
        Assert.Equal("Invalid payment method.", exception.Message);
    }
}