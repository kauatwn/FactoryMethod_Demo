using Application.Abstractions.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<Payment>(StatusCodes.Status201Created)]
    public IActionResult ProcessPayment(IProcessPaymentUseCase useCase, Payment payment)
    {
        var result = useCase.Execute(payment);
        return Ok(result);
    }
}