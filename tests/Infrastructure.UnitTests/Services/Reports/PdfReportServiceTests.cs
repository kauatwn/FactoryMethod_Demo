using Domain.Entities;
using Infrastructure.Services.Reports;

namespace Infrastructure.UnitTests.Services.Reports;

public class PdfReportServiceTests
{
    private PdfReportService Service { get; } = new("Watermark");

    [Fact]
    public void ShouldGeneratePdfReportSuccessfully()
    {
        // Arrange
        var report = new Report("Title", "Content");
        var expected = $"{report.Title}\n{report.Content} - Watermark: {Service.Watermark}";

        // Act
        string result = Service.Generate(report);

        // Assert
        Assert.Equal(expected, result);
    }
}