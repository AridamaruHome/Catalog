using System.Net;
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
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command) => Ok(await _mediator.Send(command));
}