using Newtonsoft.Json;
using SampleApplication.Core.Domain.People.Events;
using SampleApplication.Framework;

namespace SampleApplication.Core.ApplicationService.People.EventHandlers
{
    public class WritePersonCreatedToConsole : IDomainEventHandler<PersonCreated>
    {
        public Task Handle(PersonCreated domainEvent)
        {
            Console.WriteLine(JsonConvert.SerializeObject(domainEvent));
            return Task.CompletedTask;
        }
    }
    public class WriteFirstNameUpdatedToConsole : IDomainEventHandler<FirstNameChanged>
    {
        public Task Handle(FirstNameChanged domainEvent)
        {
            Console.WriteLine(JsonConvert.SerializeObject(domainEvent));
            return Task.CompletedTask;
        }
    }

    public class WriteLastNameUpdatedToConsole : IDomainEventHandler<LastNameChanged>
    {
        public Task Handle(LastNameChanged domainEvent)
        {
            Console.WriteLine(JsonConvert.SerializeObject(domainEvent));
            return Task.CompletedTask;
        }
    }
}
