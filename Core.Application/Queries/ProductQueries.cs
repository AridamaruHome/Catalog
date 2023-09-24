using Core.Domain.Aggregates.ProductAggregate;
using Core.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Queries;

public class ProductQueries : IProductQueries
{
    private readonly WarehouseContext _dbContext;

    public ProductQueries(WarehouseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> GetProductByProductId(Guid productId)
    {
        var product = await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ProductId == productId);

        if (product is null)
        {
            throw new KeyNotFoundException();
        }

        return product;
    }

    public async Task<IEnumerable<Product>> GetProducts(int pageSize, int pageIndex)
    {
        var products = await _dbContext.Products
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return products;
    }

    public async Task<int> GetProductsCount()
    {
        return await _dbContext.Products.CountAsync();
    }
}