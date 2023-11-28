    using Microsoft.AspNetCore.Mvc;
using MediatR;

// Nome da Rota
[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMessageRequest request)
    {
        var message = await _mediator.Send(request);
        return Ok(message);
    }

}