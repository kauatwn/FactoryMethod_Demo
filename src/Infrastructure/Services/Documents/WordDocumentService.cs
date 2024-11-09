using Domain.Entities;
using Domain.Interfaces.Services;

namespace Infrastructure.Services.Documents;

public class WordDocumentService : IDocumentService
{
    public string Print(Document document)
    {
        return $"Word Document: {document.Title}";
    }
}