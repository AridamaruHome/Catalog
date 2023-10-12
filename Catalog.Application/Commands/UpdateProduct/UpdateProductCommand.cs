using MediatR;

namespace Catalog.Application.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<bool>
{
    public UpdateProductCommand(string productId, string name, string description, string category, string barcode, string imageUrl)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        Category = category;
        Barcode = barcode;
        ImageUrl = imageUrl;
    }

    public string ProductId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string Category { get; init; }
    public string Barcode { get; init; }
    public string ImageUrl { get; init; }
}