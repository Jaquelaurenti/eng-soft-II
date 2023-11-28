using Microsoft.AspNetCore.Mvc;
using MediatR;

// Nome da Rota
[Route("api/[controller]")]
[ApiController]
public class ConsumerController : ControllerBase
{
    IMediator _mediator;

    public ConsumerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ConsumerMessageRequest request)
    {
        var message = await _mediator.Send(request);
        return Ok(message);
    }

}