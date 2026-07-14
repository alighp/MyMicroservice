using SampleApplication.Core.Domain;
using SampleApplication.Core.Domain.People;
using SampleApplication.Framework;
using Microsoft.Extensions.DependencyInjection;

namespace SampleApplication.Core.ApplicationService.People
{
    public partial class PersonAppService
    {
        private readonly PersonRepository personRepository;

        public PersonAppService(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        public void AddPerson(CreatePersonDto dto)
        {
            var person = new Person(dto.FirstName, dto.LastName, new PhoneNumber { Number = dto.PhoneNumber });
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

        public void AddNumberToPerson(AddNumberToPersonDto dto)
        {
            var person = personRepository.Find(dto.PersonId);
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