using SampleApplication.Core.ApplicationService.Cusomers;
using SampleApplication.Core.Domain.Customers;
using SampleApplication.Core.Domain.People;

namespace SampleApplication.Core.ApplicationService.Customers
{
    public class CustomerAppService
    {
        private readonly CustomerRepository personRepository;

        public CustomerAppService(CustomerRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        public void AddPerson(CreateCustomerDto dto)
        {
            var person = new Customer(dto.FirstName, dto.LastName, new PhoneNumber(number: dto.PhoneNumber));
            personRepository.Add(person);
        }

        public void ChangeFirstName(string firstName, long personId)
        {
            var person = personRepository.Find(personId);
            if (person == null)
                throw new ApplicationException("Person not fount");
            person.ChangeFirstName(firstName);
            personRepository.Update();

        }

        public void AddNumberToPerson(AddNumberToCustomerDto dto)
        {
            var person = personRepository.Find(dto.CustomerId);
            if (person == null)
                throw new ApplicationException("Person not fount");
            person.AddPhoneNumber(new PhoneNumber(dto.Number));
            personRepository.Update();

        }

        public void ChangeLastName(string lastName, long personId)
        {
            var person = personRepository.Find(personId);
            if (person == null)
                throw new ApplicationException("Person not fount");
            person.ChangeLastName(lastName);
            personRepository.Update();
        }



    }
}