using Infrastructure.Factories.Documents;
using Infrastructure.Services.Documents;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Infrastructure.UnitTests.Factories.Documents;

public class WordDocumentFactoryTests
{
    private Mock<IConfiguration> Configuration { get; } = new();
    private WordDocumentFactory Factory { get; }

    public WordDocumentFactoryTests()
    {
        Factory = new WordDocumentFactory(Configuration.Object);
    }

    [Fact]
    public void ShouldCreatePdfDocumentServiceWithWatermark()
    {
        // Arrange
        const string expected = "Original Watermark";
        Configuration.Setup(c => c["DocumentSettings:Watermark"]).Returns(expected);

        // Act
        var service = Factory.Create();

        // Assert
        var wordDocumentService = Assert.IsType<WordDocumentService>(service);
        Assert.Equal(expected, wordDocumentService.Watermark);
    }

    [Fact]
    public void ShouldCreateWordDocumentServiceWithDefaultWatermarkWhenNotProvided()
    {
        // Arrange
        const string expected = "Default Watermark";
        Configuration.Setup(c => c["DocumentSettings:Watermark"]).Returns(null as string);

        // Act
        var service = Factory.Create();

        // Assert
        var wordDocumentService = Assert.IsType<WordDocumentService>(service);
        Assert.Equal(expected, wordDocumentService.Watermark);
    }
}