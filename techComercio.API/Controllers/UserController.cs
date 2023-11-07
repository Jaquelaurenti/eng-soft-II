using Microsoft.AspNetCore.Mvc;
using MediatR;

// Nome da Rota
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase 
{
    IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        var user = await _mediator.Send(request);
        return Ok(user);
    }
}