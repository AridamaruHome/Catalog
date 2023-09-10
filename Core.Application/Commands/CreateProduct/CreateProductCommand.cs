using MediatR;

namespace Core.Application.Commands.CreateProduct;

public class CreateProductCommand : IRequest<bool>
{
    public CreateProductCommand(string Name, string Description, string Category, string Barcode, string ImageUrl)
    {
        this.Name = Name;
        this.Description = Description;
        this.Category = Category;
        this.Barcode = Barcode;
        this.ImageUrl = ImageUrl;
    }

    public string Name { get; init; }
    public string Description { get; init; }
    public string Category { get; init; }
    public string Barcode { get; init; }
    public string ImageUrl { get; init; }

    public void Deconstruct(out string Name, out string Description, out string Category, out string Barcode, out string ImageUrl)
    {
        Name = this.Name;
        Description = this.Description;
        Category = this.Category;
        Barcode = this.Barcode;
        ImageUrl = this.ImageUrl;
    }
}