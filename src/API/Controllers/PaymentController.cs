using Application.Abstractions.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    [HttpPost]
    public IActionResult ProcessPayment(IProcessPaymentUseCase useCase, Payment payment)
    {
        var result = useCase.Execute(payment);
        return Ok(result);
    }
}