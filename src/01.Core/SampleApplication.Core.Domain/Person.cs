namespace SampleApplication.Core.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; set; } = new();
        private Person()
        {
        }
        public Person(string firstName, string lastName, PhoneNumber phoneNumber)
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
            this.FirstName = firstName;
            this.LastName = lastName;
            PhoneNumbers.Add(phoneNumber);
        }

        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            if (PhoneNumbers.Any(x => x.Number == phoneNumber.Number))
                throw new InvalidDataException("PhoneNumber is duplicate");
            PhoneNumbers.Add(phoneNumber);
        }
    }
}