using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Moq;

namespace Application.UnitTests.UseCases;

public class GenerateReportUseCaseTests
{
    private Mock<IReportService> MockService { get; } = new();
    private Mock<IReportFactory> MockFactory { get; } = new();
    private GenerateReportUseCase UseCase { get; }

    public GenerateReportUseCaseTests()
    {
        UseCase = new GenerateReportUseCase(MockFactory.Object);
    }

    [Fact]
    public void ShouldCreateFactoryAndGenerateWhenExecuteIsCalled()
    {
        // Arrange
        var report = new Report("Title", "Content");

        MockFactory.Setup(f => f.Create()).Returns(MockService.Object);
        MockService.Setup(s => s.Generate(It.IsAny<Report>()));

        // Act
        UseCase.Execute(report);

        // Assert
        MockFactory.Verify(f => f.Create(), Times.Once);
        MockService.Verify(s => s.Generate(It.IsAny<Report>()), Times.Once);
    }
}