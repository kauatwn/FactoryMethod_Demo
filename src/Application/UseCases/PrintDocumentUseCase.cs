using Application.Abstractions.UseCases;
using Domain.Entities;
using Domain.Interfaces.Factories;

namespace Application.UseCases;

public class PrintDocumentUseCase(IDocumentFactory factory) : IPrintDocumentUseCase
{
    private IDocumentFactory Factory { get; } = factory;

    public string Execute(Document document)
    {
        var service = Factory.Create();

        return service.Print(document);
    }
}