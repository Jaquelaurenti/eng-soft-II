using Microsoft.AspNetCore.Mvc;
using MediatR;

// Nome da Rota
[Route("api/[controller]")]
[ApiController]
public class ConsumerControler : ControllerBase
{
    IMediator _mediator;

    public ConsumerControler(IMediator mediator)
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