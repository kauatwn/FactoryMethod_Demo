using Domain.Entities;
using Infrastructure.Services.Documents;

namespace Infrastructure.UnitTests.Services.Reports;

public class PdfReportServiceTests
{
    private PdfReportService Service { get; } = new("Watermark");

    [Fact]
    public void ShouldGeneratePdfReportSuccessfully()
    {
        // Arrange
        var report = new Report("Title", "Content");
        var expected = $"PDF Report: {report.Title} - {Service.Watermark}\nContent: {report.Content}";

        // Act
        string result = Service.Generate(report);

        // Assert
        Assert.Equal(expected, result);
    }
}