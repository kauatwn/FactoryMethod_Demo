using Application.Abstractions.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    [HttpPost("Generate")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public IActionResult Generate(IGenerateReportUseCase useCase, Report document)
    {
        return Ok(useCase.Execute(document));
    }
}