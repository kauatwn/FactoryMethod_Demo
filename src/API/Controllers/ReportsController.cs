using Application.Abstractions.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    [HttpPost("Generate")]
    [ProducesResponseType<Report>(StatusCodes.Status200OK)]
    public IActionResult Generate(IGenerateReportUseCase useCase, Report document)
    {
        string result = useCase.Execute(document);

        return Ok(result);
    }
}