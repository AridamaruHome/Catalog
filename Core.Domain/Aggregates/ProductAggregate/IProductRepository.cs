namespace Core.Domain.Aggregates.ProductAggregate;

public interface IProductRepository : IRepository<Product>
{
    Task Add(Product product);
    void Update(Product product);
    Task<Product> GetById(int productId);
}