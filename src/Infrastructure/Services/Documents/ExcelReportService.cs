using Domain.Entities;
using Domain.Interfaces.Services;

namespace Infrastructure.Services.Documents;

public class ExcelReportService(string template) : IReportService
{
    public string Template { get; } = template;

    public string Generate(Report report)
    {
        return $"Excel Report: {report.Title} - Template: {Template}\nContent: {report.Content}";
    }
}