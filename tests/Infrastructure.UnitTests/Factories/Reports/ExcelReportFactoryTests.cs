using Domain.Interfaces.Services;
using Infrastructure.Factories.Documents;
using Infrastructure.Services.Documents;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Infrastructure.UnitTests.Factories.Reports;

public class ExcelReportFactoryTests
{
    private Mock<IConfiguration> MockConfiguration { get; } = new();
    private ExcelReportFactory Factory { get; }

    public ExcelReportFactoryTests()
    {
        Factory = new ExcelReportFactory(MockConfiguration.Object);
    }

    [Fact]
    public void ShouldCreateExcelReportServiceWithTemplate()
    {
        // Arrange
        const string expected = "Custom Excel Template";
        MockConfiguration.Setup(c => c["ReportSettings:ExcelTemplate"]).Returns(expected);

        // Act
        IReportService service = Factory.Create();

        // Assert
        var excelReportService = Assert.IsType<ExcelReportService>(service);
        Assert.Equal(expected, excelReportService.Template);

        MockConfiguration.Verify(c => c["ReportSettings:ExcelTemplate"], Times.Once);
    }

    [Fact]
    public void ShouldCreateExcelReportServiceWithDefaultTemplateWhenNotProvided()
    {
        // Arrange
        const string expected = "Default Excel Template";
        MockConfiguration.Setup(c => c["ReportSettings:ExcelTemplate"]).Returns((string?)null);

        // Act
        IReportService service = Factory.Create();

        // Assert
        var excelReportService = Assert.IsType<ExcelReportService>(service);
        Assert.Equal(expected, excelReportService.Template);

        MockConfiguration.Verify(c => c["ReportSettings:ExcelTemplate"], Times.Once);
    }
}