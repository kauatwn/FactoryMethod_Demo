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
    public void ShouldProcessPaymentWhenPaymentMethodIsNotNull()
    {
        // Arrange
        var payment = new Payment(100.0, PaymentMethod.CreditCard);
        const string expectedMessage = "Payment processed successfully.";

        CreditCardPaymentMock.Setup(pf => pf.Create()).Returns(PaymentServiceMock.Object);

        PaymentServiceMock.Setup(ps => ps.ProcessPayment(It.IsAny<double>())).Returns(expectedMessage);

        // Act
        var result = UseCase.Execute(payment);

        // Assert
        Assert.Equal(expectedMessage, result);

        CreditCardPaymentMock.Verify(pf => pf.Create(), Times.Once);
        
        PaymentServiceMock.Verify(ps => ps.ProcessPayment(It.IsAny<double>()), Times.Once);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionWhenPaymentMethodIsNull()
    {
        // Arrange
        var payment = new Payment(100.0, null);
        const string expectedMessage = "Payment method is not set.";

        // Act
        Action act = () => UseCase.Execute(payment);

        // Assert
        var exception = Assert.Throws<InvalidOperationException>(act);
        Assert.Equal(expectedMessage, exception.Message);
        
        CreditCardPaymentMock.Verify(pf => pf.Create(), Times.Never);
        
        PaymentServiceMock.Verify(ps => ps.ProcessPayment(It.IsAny<double>()), Times.Never);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionWhenPaymentMethodIsInvalid()
    {
        // Arrange
        var payment = new Payment(100.0, (PaymentMethod)999);
        const string expectedMessage = "Invalid payment method.";

        // Act
        Action act = () => UseCase.Execute(payment);

        // Assert
        var exception = Assert.Throws<InvalidOperationException>(act);
        Assert.Equal(expectedMessage, exception.Message);
        
        CreditCardPaymentMock.Verify(pf => pf.Create(), Times.Never);
        
        PaymentServiceMock.Verify(ps => ps.ProcessPayment(It.IsAny<double>()), Times.Never);
    }
}