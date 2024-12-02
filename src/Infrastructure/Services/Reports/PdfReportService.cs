using Domain.Entities;
using Domain.Interfaces.Services;

namespace Infrastructure.Services.Reports;

public class PdfReportService(string watermark) : IReportService
{
    public string Watermark { get; } = watermark;

    public string Generate(Report report)
    {
        return $"{report.Title}\n{report.Content} - Watermark: {Watermark}";
    }
}