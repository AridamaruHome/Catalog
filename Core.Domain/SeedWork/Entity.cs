namespace Core.Domain.SeedWork;

public abstract class Entity
{
    private int? _requestedHashCode;

    private int _Id;

    public virtual int Id
    {
        get { return _Id; }
        protected set { _Id = value; }
    }

    private List<INotification> _domainEvents;

    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public bool IsTransient()
    {
        return Id == default;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return false;
        }

        if (GetType() != obj.GetType())
        {
            return false;
        }

        Entity item = (Entity)obj;

        if (item.IsTransient() || IsTransient())
        {
            return false;
        }

        return item.Id == Id;
    }
    // TODO: Equals
    // TODO: GetHashCode
    // TODO: ==
    // TODO: !=
}