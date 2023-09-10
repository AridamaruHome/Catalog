using Core.Domain.Aggregates.ProductAggregate;
using Core.Domain.SeedWork;
using Core.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly WarehouseContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ProductRepository(WarehouseContext context)
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

    public async Task<Product> GetById(int productId)
    {
        return await _context.Products.FirstOrDefaultAsync(product => product.Id == productId);
    }
}