using Domain.Interfaces.Services;

namespace Domain.Interfaces.Factories;

public interface IReportFactory
{
    IReportService Create();
}