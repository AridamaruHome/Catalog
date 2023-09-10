namespace Core.Domain.Aggregates.ProductAggregate;

public class Product : Entity, IAggregateRoot
{
    public Product()
    {
    }

    public Product(
        string name,
        string description,
        string category,
        string barcode,
        string imageUrl)
    {
        ProductId = new Guid();
        Name = name;
        Description = description;
        Category = category;
        Barcode = barcode;
        ImageUrl = imageUrl;
        CreationDate = DateTime.UtcNow;
    }

    public Guid ProductId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    public string Barcode { get; private set; }
    public string ImageUrl { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime? LastModifiedDate { get; private set; }
}