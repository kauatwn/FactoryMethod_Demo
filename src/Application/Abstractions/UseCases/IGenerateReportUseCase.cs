using Domain.Entities;

namespace Application.Abstractions.UseCases;

public interface IGenerateReportUseCase
{
    string Execute(Report report);
}