namespace SampleApplication.Framework
{
    public interface IDomainEventHandler<TDomainEvent> where  TDomainEvent : IDomainEvent 
    {
        Task Handle(TDomainEvent domainEvent); 
    }
}
