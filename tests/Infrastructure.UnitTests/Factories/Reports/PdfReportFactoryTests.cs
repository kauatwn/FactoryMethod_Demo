using Domain.Interfaces.Services;
using Infrastructure.Factories.Documents;
using Infrastructure.Services.Documents;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Infrastructure.UnitTests.Factories.Reports;

public class PdfReportFactoryTests
{
    private Mock<IConfiguration> MockConfiguration { get; } = new();
    private PdfReportFactory Factory { get; }

    public PdfReportFactoryTests()
    {
        Factory = new PdfReportFactory(MockConfiguration.Object);
    }

    [Fact]
    public void ShouldCreatePdfReportServiceWithWatermark()
    {
        // Arrange
        const string expected = "Original PDF Watermark";
        MockConfiguration.Setup(c => c["ReportSettings:PdfWatermark"]).Returns(expected);

        // Act
        IReportService service = Factory.Create();

        // Assert
        var pdfReportService = Assert.IsType<PdfReportService>(service);
        Assert.Equal(expected, pdfReportService.Watermark);
        
        MockConfiguration.Verify(c => c["ReportSettings:PdfWatermark"], Times.Once);
    }

    [Fact]
    public void ShouldCreatePdfReportServiceWithDefaultWatermarkWhenNotProvided()
    {
        // Arrange
        const string expected = "Default PDF Watermark";
        MockConfiguration.Setup(c => c["ReportSettings:PdfWatermark"]).Returns((string?)null);

        // Act
        IReportService service = Factory.Create();

        // Assert
        var pdfReportService = Assert.IsType<PdfReportService>(service);
        Assert.Equal(expected, pdfReportService.Watermark);
        
        MockConfiguration.Verify(c => c["ReportSettings:PdfWatermark"], Times.Once);
    }
}