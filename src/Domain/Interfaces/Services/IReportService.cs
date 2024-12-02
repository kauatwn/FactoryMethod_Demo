using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IReportService
{
    string Generate(Report report);
}