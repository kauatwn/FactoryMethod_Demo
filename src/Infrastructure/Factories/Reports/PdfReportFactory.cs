using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Infrastructure.Options;
using Infrastructure.Services.Reports;
using Microsoft.Extensions.Options;

namespace Infrastructure.Factories.Reports;

public class PdfReportFactory(IOptions<ReportOptions> options) : IReportFactory
{
    private IOptions<ReportOptions> Options { get; } = options;

    public IReportService Create()
    {
        string watermark = Options.Value.PdfWatermark ?? "Default PDF Watermark";

        return new PdfReportService(watermark);
    }
}