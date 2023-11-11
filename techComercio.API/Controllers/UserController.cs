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

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateUserResponse>>
        Update(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return BadRequest();
        }

        var deleteRequest = new DeleteUserRequest(id.Value);
        var response = await _mediator.Send(deleteRequest, cancellationToken);
        return Ok(response);
    }
    [HttpGet]
    public async Task<ActionResult<List<GetAllUserResponse>>> GetAll (CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
        return Ok(response);    }
}