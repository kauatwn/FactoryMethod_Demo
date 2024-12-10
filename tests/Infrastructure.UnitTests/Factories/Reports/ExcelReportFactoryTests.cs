using Domain.Interfaces.Services;
using Infrastructure.Factories.Reports;
using Infrastructure.Options;
using Infrastructure.Services.Reports;
using Microsoft.Extensions.Options;
using Moq;

namespace Infrastructure.UnitTests.Factories.Reports;

public class ExcelReportFactoryTests
{
    private Mock<IOptions<ReportOptions>> MockOptions { get; } = new();
    private ExcelReportFactory Factory { get; }

    public ExcelReportFactoryTests()
    {
        Factory = new ExcelReportFactory(MockOptions.Object);
    }

    [Fact]
    public void ShouldCreateExcelReportServiceWithTemplateWhenProvided()
    {
        // Arrange
        var options = new ReportOptions { ExcelTemplate = "Custom Excel Template" };
        const string expected = "Custom Excel Template";

        MockOptions.Setup(o => o.Value).Returns(options);

        // Act
        IReportService service = Factory.Create();

        // Assert
        var excelReportService = Assert.IsType<ExcelReportService>(service);
        Assert.Equal(expected, excelReportService.Template);

        MockOptions.Verify(o => o.Value, Times.Once);
    }

    [Fact]
    public void ShouldCreateExcelReportServiceWithDefaultTemplateWhenNotProvided()
    {
        // Arrange
        var options = new ReportOptions();
        const string expected = "Default Excel Template";

        MockOptions.Setup(o => o.Value).Returns(options);

        // Act
        IReportService service = Factory.Create();

        // Assert
        var excelReportService = Assert.IsType<ExcelReportService>(service);
        Assert.Equal(expected, excelReportService.Template);

        MockOptions.Verify(o => o.Value, Times.Once);
    }
}