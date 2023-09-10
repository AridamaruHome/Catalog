using MediatR;

namespace Core.Application.Commands.CreateProduct;

public class CreateProductCommand : IRequest<bool>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    public string Barcode { get; private set; }
    public string ImageUrl { get; private set; }
}