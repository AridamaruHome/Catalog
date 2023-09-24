using System.Net;
using Core.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Commands.CreateProduct;

namespace Core.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command, [FromHeader(Name = "x-requestid")] string requestId)
    {
        bool commandResult = false;
        if (Guid.TryParse(requestId, out var guid) && guid != Guid.Empty)
        {
            var createProductCommand = new IdentifiedCommand<CreateProductCommand, bool>(command, guid);
            commandResult = await _mediator.Send(createProductCommand);
        }
        
        if (!commandResult)
        {
            return BadRequest();
        }
        return Ok();
    }
}