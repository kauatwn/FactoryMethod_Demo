using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IDocumentService
{
    string Print(Document document);
}