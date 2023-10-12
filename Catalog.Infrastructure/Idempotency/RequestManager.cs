using Catalog.Domain.Exceptions;
using Catalog.Infrastructure.Context;

namespace Catalog.Infrastructure.Idempotency;

public class RequestManager : IRequestManager
{
    private readonly CatalogContext _context;

    public RequestManager(CatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<bool> Exist(Guid id)
    {
        var request = await _context.FindAsync<ClientRequest>(id);
        return request is not null;
    }

    public async Task CreateRequestForCommand<T>(Guid id)
    {
        var exists = await Exist(id);

        var request = exists
            ? throw new CatalogDomainException($"Request with {id} already exists")
            : new ClientRequest
            {
                Id = id,
                Name = typeof(T).Name,
                Time = DateTime.UtcNow
            };

        _context.Add(request);
        await _context.SaveChangesAsync();
    }
}