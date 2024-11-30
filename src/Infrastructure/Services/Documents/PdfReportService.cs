using Domain.Entities;
using Domain.Interfaces.Services;

namespace Infrastructure.Services.Documents;

public class PdfReportService(string watermark) : IReportService
{
    public string Watermark { get; } = watermark;

    public string Generate(Report report)
    {
        return $"PDF Report: {report.Title} - {Watermark}\nContent: {report.Content}";
    }
}