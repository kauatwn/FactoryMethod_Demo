using Application.Abstractions.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController(IProcessPaymentUseCase useCase) : ControllerBase
{
    private IProcessPaymentUseCase UseCase { get; } = useCase;

    [HttpPost]
    public IActionResult ProcessPayment(Payment payment)
    {
        var result = UseCase.Execute(payment);
        return Ok(result);
    }
}