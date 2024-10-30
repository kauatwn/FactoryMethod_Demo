using Application.Abstractions.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentsController : ControllerBase
{
    [HttpPost("Print")]
    [ProducesResponseType<Document>(StatusCodes.Status201Created)]
    public IActionResult Print(IPrintDocumentUseCase useCase, Document document)
    {
        var result = useCase.Execute(document);
        return Created(string.Empty, result);
    }
}