using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Infrastructure.Options;
using Infrastructure.Services.Reports;
using Microsoft.Extensions.Options;

namespace Infrastructure.Factories.Reports;

public class ExcelReportFactory(IOptions<ReportOptions> options) : IReportFactory
{
    private IOptions<ReportOptions> Options { get; } = options;

    public IReportService Create()
    {
        string template = Options.Value.ExcelTemplate ?? "Default Excel Template";

        return new ExcelReportService(template);
    }
}