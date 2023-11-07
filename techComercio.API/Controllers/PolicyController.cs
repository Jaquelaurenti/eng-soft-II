using Microsoft.AspNetCore.Mvc;
using MediatR;

// Nome da Rota
[Route("api/[controller]")]
[ApiController]
public class PolicyController : ControllerBase 
{
    IMediator _mediator;

    public PolicyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePolicyRequest request)
    {
        var policy = await _mediator.Send(request);
        return Ok(policy);
    }
}