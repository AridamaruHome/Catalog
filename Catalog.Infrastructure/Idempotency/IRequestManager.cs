namespace Catalog.Infrastructure.Idempotency;

public interface IRequestManager
{
    Task<bool> Exist(Guid id);
    Task CreateRequestForCommand<T>(Guid id);
}