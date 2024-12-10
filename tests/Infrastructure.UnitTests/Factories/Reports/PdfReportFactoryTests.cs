using Domain.Interfaces.Services;
using Infrastructure.Factories.Reports;
using Infrastructure.Options;
using Infrastructure.Services.Reports;
using Microsoft.Extensions.Options;
using Moq;

namespace Infrastructure.UnitTests.Factories.Reports;

public class PdfReportFactoryTests
{
    private Mock<IOptions<ReportOptions>> MockOptions { get; } = new();
    private PdfReportFactory Factory { get; }

    public PdfReportFactoryTests()
    {
        Factory = new PdfReportFactory(MockOptions.Object);
    }

    [Fact]
    public void ShouldCreatePdfReportServiceWithWatermarkWhenProvided()
    {
        // Arrange
        var options = new ReportOptions { PdfWatermark = "Custom PDF Watermark" };
        const string expected = "Custom PDF Watermark";

        MockOptions.Setup(o => o.Value).Returns(options);

        // Act
        IReportService service = Factory.Create();

        // Assert
        var pdfReportService = Assert.IsType<PdfReportService>(service);
        Assert.Equal(expected, pdfReportService.Watermark);

        MockOptions.Verify(o => o.Value, Times.Once);
    }

    [Fact]
    public void ShouldCreatePdfReportServiceWithDefaultWatermarkWhenNotProvided()
    {
        // Arrange
        var options = new ReportOptions();
        const string expected = "Default PDF Watermark";

        MockOptions.Setup(o => o.Value).Returns(options);

        // Act
        IReportService service = Factory.Create();

        // Assert
        var pdfReportService = Assert.IsType<PdfReportService>(service);
        Assert.Equal(expected, pdfReportService.Watermark);

        MockOptions.Verify(o => o.Value, Times.Once);
    }
}