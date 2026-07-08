namespace SampleApplication.Framework
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
