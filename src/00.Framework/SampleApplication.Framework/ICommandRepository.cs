namespace SampleApplication.Framework
{
    public interface ICommandRepository<TAggregate, TId> where TAggregate : AggregateRoot<TId>
    {
        TAggregate Get(TId id);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
