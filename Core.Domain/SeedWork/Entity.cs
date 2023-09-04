namespace Core.Domain.SeedWork;

public abstract class Entity
{
    private int? _requestedHashCode;

    private int _Id;

    public virtual int Id
    {
        get
        {
            return _Id;
        }
        protected set
        {
            _Id = value;
        }
    }

    private List<INotification> _domainEvents;

    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }
    // TODO: AddDomainEvent
    // TODO: RemoveDomainEvent
    // TODO: ClearDomainEvents
    // TODO: Equals
    // TODO: GetHashCode
    // TODO: ==
    // TODO: !=
}