using Catalog.Domain.Aggregates.ProductAggregate;
using Catalog.Domain.Exceptions;
using Catalog.Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByProductId(Guid.Parse(command.ProductId));

        if (product is null)
        {
            throw new CatalogDomainException($"Product with {command.ProductId} id not found");
        }


        return await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}

public class CancelOrderIdentifiedCommandHandler : IdentifiedCommandHandler<UpdateProductCommand, bool>
{
    public CancelOrderIdentifiedCommandHandler(IMediator mediator,
        IRequestManager requestManager,
        ILogger<IdentifiedCommandHandler<UpdateProductCommand, bool>> logger) : base(mediator, requestManager, logger)
    {
    }

    protected override bool CreatedResultForDuplicateRequest()
    {
        return false;
    }
}