namespace Catalog.Domain.Aggregates.ProductAggregate;

public interface IProductRepository : IRepository<Product>
{
    Task Add(Product product);
    void Update(Product product);
    Task<Product> FindByProductId(Guid productId);
}