using Application.Abstractions.UseCases;
using Domain.Entities;
using Domain.Interfaces.Factories;

namespace Application.UseCases;

public class PrintDocumentUseCase(IDocumentFactory documentFactory) : IPrintDocumentUseCase
{
    private IDocumentFactory DocumentFactory { get; } = documentFactory;

    public string Execute(Document document)
    {
        var service = DocumentFactory.Create();

        return service.PrintDocument(document);
    }
}