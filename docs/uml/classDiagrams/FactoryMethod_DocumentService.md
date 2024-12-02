# Factory Method Pattern - Document Service Diagram

Este diagrama UML representa a implementação do padrão **Factory Method** para a criação de serviços de documentos.

```mermaid
classDiagram
    class IDocumentService {
        <<interface>>
        Print(document : Document) string
    }

    class PdfDocumentService {
        + Print(document : Document) string
    }

    %% Implementação
    IDocumentService <|.. PdfDocumentService : "implements"

    class IDocumentFactory {
        <<interface>>
        Create() IDocumentService
    }

    class PdfDocumentFactory {
        + Create() IDocumentService
    }

    %% Implementação
    IDocumentFactory <|.. PdfDocumentFactory : "implements"

    %% Associação
    PdfDocumentFactory --> PdfDocumentService : "creates"

    note for IDocumentService "Document service"
    note for PdfDocumentService "Concrete document service"
    note for IDocumentFactory "Creator"
    note for PdfDocumentFactory "Concrete creator"
    ```
