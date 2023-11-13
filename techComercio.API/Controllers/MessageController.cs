using Microsoft.AspNetCore.Mvc;
using MediatR;

// Nome da Rota
[Route("api/[controller]")]
[ApiController]
public class MessageControler : ControllerBase 
{
    IMediator _mediator;

    public MessageControler(IMediator mediator)
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