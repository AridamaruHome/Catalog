using MediatR;

namespace Core.Application.Commands.CreateProduct;

public class CreateProductCommand : IRequest<bool>
{
    public CreateProductCommand(string name, string description, string category, string barcode, string imageUrl)
    {
        Name = name;
        Description = description;
        Category = category;
        Barcode = barcode;
        ImageUrl = imageUrl;
    }

    public string Name { get; init; }
    public string Description { get; init; }
    public string Category { get; init; }
    public string Barcode { get; init; }
    public string ImageUrl { get; init; }
}