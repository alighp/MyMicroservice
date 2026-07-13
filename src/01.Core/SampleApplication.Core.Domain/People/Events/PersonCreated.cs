using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.People.Events
{
    public class PersonCreated : IDomainEvent
    {
        public string FirstName { get; }
        public string LastName { get; }
        public PersonCreated(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;    
        }
    }

}
