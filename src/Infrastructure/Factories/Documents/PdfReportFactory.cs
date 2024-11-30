using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Infrastructure.Services.Documents;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Factories.Documents;

public class PdfReportFactory(IConfiguration configuration) : IReportFactory
{
    private IConfiguration Configuration { get; } = configuration;

    public IReportService Create()
    {
        string watermark = Configuration["ReportSettings:PdfWatermark"] ?? "Default PDF Watermark";

        return new PdfReportService(watermark);
    }
}