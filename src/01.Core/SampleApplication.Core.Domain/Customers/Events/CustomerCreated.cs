using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.Customers.Events
{
    public class CustomerCreated : IDomainEvent
    {
        public string FirstName { get; }
        public string LastName { get; }
        public CustomerCreated(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
