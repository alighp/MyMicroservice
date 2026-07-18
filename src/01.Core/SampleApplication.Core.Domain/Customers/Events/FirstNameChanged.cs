using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.Customers.Events
{
    public class FirstNameChanged : IDomainEvent
    {
        public string FirstName { get; }
        public long Id { get; }
        public FirstNameChanged(string firstName, long id)
        {
            FirstName = firstName;
            Id = id;
        }
    }

}
