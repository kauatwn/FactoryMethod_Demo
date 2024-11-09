using Infrastructure.Factories.Documents;
using Infrastructure.Services.Documents;

namespace Infrastructure.UnitTests.Factories;

public class DocumentFactoryTests
{
    [Fact]
    public void ShouldCreatePdfDocumentService()
    {
        // Arrange
        var factory = new PdfDocumentFactory();

        // Act
        var service = factory.Create();

        // Assert
        Assert.IsType<PdfDocumentService>(service);
    }

    [Fact]
    public void ShouldCreateWordDocumentService()
    {
        // Arrange
        var factory = new WordDocumentFactory();

        // Act
        var service = factory.Create();

        // Assert
        Assert.IsType<WordDocumentService>(service);
    }
}