using Core.Domain.Aggregates.ProductAggregate;

namespace Core.Application.Queries;

public interface IProductQueries
{
    Task<Product> GetProductByProductId(Guid productId);
    Task<IEnumerable<Product>> GetProducts(int pageSize, int pageIndex);
    Task<int> GetProductsCount();
}