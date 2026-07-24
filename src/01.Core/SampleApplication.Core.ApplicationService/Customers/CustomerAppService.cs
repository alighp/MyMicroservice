using SampleApplication.Core.ApplicationService.Cusomers;
using SampleApplication.Core.Domain.Customers;
using SampleApplication.Core.Domain.Customers.Entities;

namespace SampleApplication.Core.ApplicationService.Customers
{
    public class CustomerAppService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerAppService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public void AddCustomer(CreateCustomerDto dto)
        {
            var person = new Customer(dto.FirstName, dto.LastName, new PhoneNumber(number: dto.PhoneNumber));
            customerRepository.Add(person);
        }

        public void ChangeFirstName(string firstName, long customerId)
        {
            var person = customerRepository.Find(customerId);
            if (person == null)
                throw new ApplicationException("Customer not fount");
            person.ChangeFirstName(firstName);
            customerRepository.SaveChanges();

        }

        public void AddNumberToPerson(AddNumberToCustomerDto dto)
        {
            var person = customerRepository.Find(dto.CustomerId);
            if (person == null)
                throw new ApplicationException("Customer not fount");
            person.AddPhoneNumber(new PhoneNumber(dto.Number));
            customerRepository.SaveChanges();

        }

        public void ChangeLastName(string lastName, long customerId)
        {
            var person = customerRepository.Find(customerId);
            if (person == null)
                throw new ApplicationException("Customer not fount");
            person.ChangeLastName(lastName);
            customerRepository.SaveChanges();
        }



    }
}