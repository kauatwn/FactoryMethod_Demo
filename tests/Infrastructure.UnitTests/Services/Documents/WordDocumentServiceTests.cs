using Domain.Entities;
using Infrastructure.Services.Documents;

namespace Infrastructure.UnitTests.Services.Documents;

public class WordDocumentServiceTests
{
    private WordDocumentService Service { get; } = new();

    [Fact]
    public void ShouldPrintWordDocumentSuccessfully()
    {
        // Arrange
        var document = new Document("Title");
        var expected = $"Word Document: {document.Title}";

        // Act
        var result = Service.Print(document);

        // Assert
        Assert.Equal(expected, result);
    }
}