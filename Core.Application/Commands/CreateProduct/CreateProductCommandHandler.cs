using Core.Domain.Aggregates.ProductAggregate;
using Core.Infrastructure.Context;
using Core.Infrastructure.Idempotency;
using Core.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Application.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product(
            command.Name,
            command.Description,
            command.Category,
            command.Barcode,
            command.ImageUrl);

        await _productRepository.Add(product);
        return await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}

public class CancelOrderIdentifiedCommandHandler : IdentifiedCommandHandler<CreateProductCommand, bool>
{
    public CancelOrderIdentifiedCommandHandler(
        IMediator mediator,
        IRequestManager requestManager,
        ILogger<IdentifiedCommandHandler<CreateProductCommand, bool>> logger)
        : base(mediator, requestManager, logger)
    {
    }

    protected override bool CreatedResultForDuplicateRequest()
    {
        return false;
    }
}