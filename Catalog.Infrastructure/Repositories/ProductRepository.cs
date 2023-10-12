using Catalog.Domain.Aggregates.ProductAggregate;
using Catalog.Domain.SeedWork;
using Catalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CatalogContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ProductRepository(CatalogContext context)
    {
        _context = context;
    }

    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public async Task<Product> FindByProductId(Guid productId)
    {
        return await _context.Products.FirstOrDefaultAsync(product => product.ProductId == productId);
    }
}