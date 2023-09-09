namespace Core.Domain.Aggregates.ProductAggregate;

public class Product : Entity, IAggregateRoot
{
    public Product()
    {
    }

    public string Name { get; private set; }
}