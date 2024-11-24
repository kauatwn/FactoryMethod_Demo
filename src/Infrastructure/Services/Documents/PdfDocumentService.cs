using Domain.Entities;
using Domain.Interfaces.Services;

namespace Infrastructure.Services.Documents;

public class PdfDocumentService(string watermark) : IDocumentService
{
    public string Watermark { get; private set; } = watermark;

    public string Print(Document document)
    {
        return $"PDF Document: {document.Title} - {Watermark}";
    }
}