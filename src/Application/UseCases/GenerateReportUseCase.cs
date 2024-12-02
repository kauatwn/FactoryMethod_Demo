using Application.Abstractions.UseCases;
using Domain.Entities;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;

namespace Application.UseCases;

public class GenerateReportUseCase(IReportFactory factory) : IGenerateReportUseCase
{
    private IReportFactory Factory { get; } = factory;

    public string Execute(Report report)
    {
        IReportService service = Factory.Create();

        return service.Generate(report);
    }
}