using Domain.Entities;
using Infrastructure.Services.Reports;

namespace Infrastructure.UnitTests.Services.Reports;

public class ExcelReportServiceTests
{
    private ExcelReportService Service { get; } = new("Template");

    [Fact]
    public void ShouldGenerateExcelReportSuccessfully()
    {
        // Arrange
        var report = new Report("Title", "Content");
        var expected = $"{report.Title}\n{report.Content} - Template: {Service.Template}";

        // Act
        string result = Service.Generate(report);

        // Assert
        Assert.Equal(expected, result);
    }
}