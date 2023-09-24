using System.Net;
using System.Reflection.Metadata.Ecma335;
using Core.API.ViewModels;
using Core.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Commands.CreateProduct;
using Core.Application.Queries;
using Core.Domain.Aggregates.ProductAggregate;

namespace Core.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProductQueries _productQueries;

    public ProductsController(IMediator mediator,
        IProductQueries productQueries)
    {
        _mediator = mediator;
        _productQueries = productQueries;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command,
        [FromHeader(Name = "x-requestid")] string requestId)
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

    [HttpGet("{productId}")]
    [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetProductById(string productId)
    {
        if (!Guid.TryParse(productId, out var productGuid))
        {
            return BadRequest();
        }

        try
        {
            var product = await _productQueries.GetProductByProductId(productGuid);

            return Ok(new ProductDto(product.ProductId,
                product.Name,
                product.Description,
                product.Category,
                product.Barcode,
                product.ImageUrl,
                product.CreationDate));
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetProducts([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
    {
        var totalItems = await _productQueries.GetProductsCount();
        var products = (await _productQueries.GetProducts(pageSize, pageIndex))
            .Select(product => new ProductDto(product.ProductId,
                product.Name,
                product.Description,
                product.Category,
                product.Barcode,
                product.ImageUrl,
                product.CreationDate));

        return Ok(new PaginatedItems<ProductDto>(pageIndex, pageSize, totalItems, products));
    }
}