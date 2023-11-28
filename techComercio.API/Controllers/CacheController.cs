using Microsoft.AspNetCore.Mvc;
using MediatR;

// Nome da Rota
[Route("api/[controller]")]
[ApiController]
public class CacheController : ControllerBase
{
    IMediator _mediator;

    public CacheController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CacheRequest request)
    {
        var message = await _mediator.Send(request);
        return Ok(message);
    }

}