using SampleApplication.Core.Domain.Customers.Events;

namespace SampleApplication.Core.Domain.People
{
    public class Customer : Entity<long>
    {
        //public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public List<PhoneNumber> PhoneNumbers { get; set; } = new();
        private Customer()
        {
        }
        public Customer(string firstName, string lastName, PhoneNumber phoneNumber)
        {
            if (firstName == null || string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException("Invalid input for firstName");
            }
            if (lastName == null || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException("Invalid input for lastName");
            }
            if (phoneNumber == null || string.IsNullOrWhiteSpace(phoneNumber.Number))
            {
                throw new ArgumentNullException("Invalid input for phoneNumber");
            }
            FirstName = firstName;
            LastName = lastName;
            PhoneNumbers.Add(phoneNumber);
            CustomerCreated @event = new(FirstName,LastName);
            AddEvent(@event);
        }

        public void ChangeFirstName(string firstName)
        {
            if (firstName == null || string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException("Invalid input for firstName");
            }
            FirstName = firstName;
            FirstNameChanged @event = new(FirstName, Id);
            AddEvent(@event);
        }

        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            if (PhoneNumbers.Any(x => x.Number == phoneNumber.Number))
                throw new InvalidDataException("PhoneNumber is duplicate");
            PhoneNumbers.Add(phoneNumber);
        }
        public override bool Equals(object? obj)
        {
            var other = obj as Customer;
            if (other == null)
                return false;

            return other.Id == Id;
        }

        public void ChangeLastName(string lastName)
        {
            if (lastName == null || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException("Invalid input for lastName");
            }
            LastName = lastName;
            LastNameChanged @event = new(LastName, Id);
            AddEvent(@event);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}