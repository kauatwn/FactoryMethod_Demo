using Domain.Entities;
using Domain.Interfaces.Services;

namespace Infrastructure.Services.Documents;

public class PdfDocumentService : IDocumentService
{
    public string PrintDocument(Document document)
    {
        return $"PDF Document: {document.Title}";
    }
}