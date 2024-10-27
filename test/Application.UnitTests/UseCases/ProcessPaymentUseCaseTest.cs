using Application.UseCases;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Moq;

namespace Application.UnitTests.UseCases;

public class ProcessPaymentUseCaseTest
{
    private Mock<IPaymentFactory> CreditCardFactoryMock { get; } = new();
    private Mock<IPaymentFactory> DebitCardFactoryMock { get; } = new();
    private Mock<IPaymentService> ServiceMock { get; } = new();
    private ProcessPaymentUseCase UseCase { get; }

    public ProcessPaymentUseCaseTest()
    {
        UseCase = new ProcessPaymentUseCase(CreditCardFactoryMock.Object, DebitCardFactoryMock.Object);
    }

    [Fact]
    public void ShouldProcessPaymentWhenPaymentMethodIsNotNull()
    {
        // Arrange
        var payment = new Payment(100.0, PaymentMethod.CreditCard);
        const string expectedMessage = "Payment processed successfully.";

        CreditCardFactoryMock.Setup(pf => pf.Create()).Returns(ServiceMock.Object);

        ServiceMock.Setup(ps => ps.ProcessPayment(It.IsAny<double>())).Returns(expectedMessage);

        // Act
        var result = UseCase.Execute(payment);

        // Assert
        Assert.Equal(expectedMessage, result);

        CreditCardFactoryMock.Verify(pf => pf.Create(), Times.Once);

        ServiceMock.Verify(ps => ps.ProcessPayment(It.IsAny<double>()), Times.Once);
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

        CreditCardFactoryMock.Verify(pf => pf.Create(), Times.Never);

        ServiceMock.Verify(ps => ps.ProcessPayment(It.IsAny<double>()), Times.Never);
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

        CreditCardFactoryMock.Verify(pf => pf.Create(), Times.Never);

        ServiceMock.Verify(ps => ps.ProcessPayment(It.IsAny<double>()), Times.Never);
    }
}