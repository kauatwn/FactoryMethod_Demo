using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IDocumentService
{
    string PrintDocument(Document document);
}