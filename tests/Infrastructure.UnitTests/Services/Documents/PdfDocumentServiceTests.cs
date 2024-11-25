using Domain.Entities;
using Infrastructure.Services.Documents;

namespace Infrastructure.UnitTests.Services.Documents;

public class PdfDocumentServiceTests
{
    private PdfDocumentService Service { get; } = new("Watermark");

    [Fact]
    public void ShouldPrintPdfDocumentSuccessfully()
    {
        // Arrange
        var document = new Document("Title");
        var expected = $"PDF Document: {document.Title} - {Service.Watermark}";

        // Act
        var result = Service.Print(document);

        // Assert
        Assert.Equal(expected, result);
    }
}