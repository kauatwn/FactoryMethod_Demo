using Domain.Entities;
using Domain.Interfaces.Services;

namespace Infrastructure.Services.Reports;

public class ExcelReportService(string template) : IReportService
{
    public string Template { get; } = template;

    public string Generate(Report report)
    {
        return $"{report.Title}\n{report.Content} - Template: {Template}";
    }
}