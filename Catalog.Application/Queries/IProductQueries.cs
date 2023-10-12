using Catalog.Domain.Aggregates.ProductAggregate;

namespace Catalog.Application.Queries;

public interface IProductQueries
{
    Task<Product> GetProductByProductId(Guid productId);
    Task<IEnumerable<Product>> GetProducts(int pageSize, int pageIndex);
    Task<int> GetProductsCount();
}