using Domain.Entities;
using Infrastructure.Services.Documents;

namespace Infrastructure.UnitTests.Services.Reports;

public class ExcelReportServiceTests
{
    private ExcelReportService Service { get; } = new("Template");

    [Fact]
    public void ShouldGenerateExcelReportSuccessfully()
    {
        // Arrange
        var report = new Report("Title", "Content");
        var expected = $"Excel Report: {report.Title} - Template: {Service.Template}\nContent: {report.Content}";

        // Act
        string result = Service.Generate(report);

        // Assert
        Assert.Equal(expected, result);
    }
}