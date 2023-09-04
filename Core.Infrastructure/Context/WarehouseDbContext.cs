using Core.Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Context;

public class WarehouseDbContext : DbContext, IUnitOfWork
{
    public const string DEFAULT_SCHEMA = "Warehouse";
    // public DbSet<T> Ts {get;set;}

    private readonly IMediator _mediator;
    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options){}
    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}