using Microsoft.AspNetCore.Mvc;
using MediatR;

// Nome da Rota
[Route("api/[controller]")]
[ApiController]
public class DraftContractControler : ControllerBase
{
    IMediator _mediator;

    public DraftContractControler(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDraftContractRequest request)
    {
        var message = await _mediator.Send(request);
        return Ok(message);
    }
}