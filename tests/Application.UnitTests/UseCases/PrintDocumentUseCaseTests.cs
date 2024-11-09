using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Moq;

namespace Application.UnitTests.UseCases;

public class PrintDocumentUseCaseTests
{
    private Mock<IDocumentFactory> DocumentFactoryMock { get; } = new();
    private Mock<IDocumentService> DocumentServiceMock { get; } = new();
    private PrintDocumentUseCase UseCase { get; }

    public PrintDocumentUseCaseTests()
    {
        UseCase = new PrintDocumentUseCase(DocumentFactoryMock.Object);
    }

    [Fact]
    public void ShouldPrintDocumentSuccessfully()
    {
        // Arrange
        var document = new Document("Title");
        const string expected = "Document printed successfully.";

        DocumentFactoryMock.Setup(df => df.Create()).Returns(DocumentServiceMock.Object);
        DocumentServiceMock.Setup(ds => ds.Print(It.IsAny<Document>())).Returns(expected);

        // Act
        var result = UseCase.Execute(document);

        // Assert
        Assert.Equal(expected, result);
        DocumentFactoryMock.Verify(df => df.Create(), Times.Once);
        DocumentServiceMock.Verify(ds => ds.Print(It.IsAny<Document>()), Times.Once);
    }
}