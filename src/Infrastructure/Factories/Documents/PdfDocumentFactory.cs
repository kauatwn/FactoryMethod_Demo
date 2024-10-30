using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Infrastructure.Services.Documents;

namespace Infrastructure.Factories.Documents;

public class PdfDocumentFactory : IDocumentFactory
{
    public IDocumentService Create()
    {
        return new PdfDocumentService();
    }
}