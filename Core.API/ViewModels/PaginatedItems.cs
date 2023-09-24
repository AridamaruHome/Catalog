using System.Security.Principal;

namespace Core.API.ViewModels;

public class PaginatedItems<TEntity> where TEntity : class
{
    public int PageSize { get; private set; }
    public int PageIndex { get; private set; }
    public int Count { get; private set; }
    public IEnumerable<TEntity> Data { get; private set; }

    public PaginatedItems(int pageSize, int pageIndex, int count, IEnumerable<TEntity> data)
    {
        PageSize = pageSize;
        PageIndex = pageIndex;
        Count = count;
        Data = data;
    }
}