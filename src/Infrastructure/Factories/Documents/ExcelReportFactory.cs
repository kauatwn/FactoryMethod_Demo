using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Infrastructure.Services.Documents;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Factories.Documents;

public class ExcelReportFactory(IConfiguration configuration) : IReportFactory
{
    private IConfiguration Configuration { get; } = configuration;

    public IReportService Create()
    {
        string template = Configuration["ReportSettings:ExcelTemplate"] ?? "Default Excel Template";

        return new ExcelReportService(template);
    }
}