using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Moq;

namespace Application.UnitTests.UseCases;

public class ProcessPaymentUseCaseTest
{
    private Mock<IDocumentFactory> DocumentFactoryMock { get; } = new();
    private Mock<IDocumentService> DocumentServiceMock { get; } = new();
    private PrintDocumentUseCase UseCase { get; }

    public ProcessPaymentUseCaseTest()
    {
        UseCase = new PrintDocumentUseCase(DocumentFactoryMock.Object);
    }

    [Fact]
    public void ShouldPrintDocumentSuccessfully()
    {
        // Arrange
        var document = new Document("Title");
        const string expected = "Document printed successfully.";

        DocumentFactoryMock.Setup(pf => pf.Create()).Returns(DocumentServiceMock.Object);

        DocumentServiceMock.Setup(ps => ps.PrintDocument(It.IsAny<Document>())).Returns(expected);

        // Act
        var result = UseCase.Execute(document);

        // Assert
        Assert.Equal(expected, result);

        DocumentFactoryMock.Verify(pf => pf.Create(), Times.Once);

        DocumentServiceMock.Verify(ps => ps.PrintDocument(It.IsAny<Document>()), Times.Once);
    }
}