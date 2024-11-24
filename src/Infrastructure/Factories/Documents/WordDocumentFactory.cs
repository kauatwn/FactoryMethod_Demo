using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Infrastructure.Services.Documents;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Factories.Documents;

public class WordDocumentFactory(IConfiguration configuration) : IDocumentFactory
{
    private IConfiguration Configuration { get; } = configuration;

    public IDocumentService Create()
    {
        var watermark = Configuration["DocumentSettings:Watermark"] ?? "Default Watermark";

        return new WordDocumentService(watermark);
    }
}