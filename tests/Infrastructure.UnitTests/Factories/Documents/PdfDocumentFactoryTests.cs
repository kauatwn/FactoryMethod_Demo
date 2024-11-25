using Infrastructure.Factories.Documents;
using Infrastructure.Services.Documents;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Infrastructure.UnitTests.Factories.Documents;

public class PdfDocumentFactoryTests
{
    private Mock<IConfiguration> Configuration { get; } = new();
    private PdfDocumentFactory Factory { get; }

    public PdfDocumentFactoryTests()
    {
        Factory = new PdfDocumentFactory(Configuration.Object);
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
        var pdfDocumentService = Assert.IsType<PdfDocumentService>(service);
        Assert.Equal(expected, pdfDocumentService.Watermark);
    }

    [Fact]
    public void ShouldCreatePdfDocumentServiceWithDefaultWatermarkWhenNotProvided()
    {
        // Arrange
        const string expected = "Default Watermark";
        Configuration.Setup(c => c["DocumentSettings:Watermark"]).Returns(null as string);

        // Act
        var service = Factory.Create();

        // Assert
        var pdfDocumentService = Assert.IsType<PdfDocumentService>(service);
        Assert.Equal(expected, pdfDocumentService.Watermark);
    }
}