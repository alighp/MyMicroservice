using SampleApplication.Core.Domain;

namespace SampleApplication.Core.ApplicationService
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
        public void AddNumberToPerson(AddNumberToPersonDto dto) 
        {
            var person = personRepository.Find(dto.PersonId);
            if (person == null)
                throw new ApplicationException("Person not fount");
            person.AddPhoneNumber(new PhoneNumber(dto.Number));
            personRepository.Update();
            
        }
    }
}