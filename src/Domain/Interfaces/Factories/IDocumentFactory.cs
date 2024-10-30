using Domain.Interfaces.Services;

namespace Domain.Interfaces.Factories;

public interface IDocumentFactory
{
    IDocumentService Create();
}