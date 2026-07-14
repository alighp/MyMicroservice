using Newtonsoft.Json;
using SampleApplication.Core.Domain.People.Events;
using SampleApplication.Framework;

namespace SampleApplication.Core.ApplicationService.People.EventHandlers
{
    public class WritePersonCreatedToConsole : IDomainEventHandler<PersonCreated>
    {
        public async Task Handle(PersonCreated domainEvent)
        {
            Console.WriteLine(JsonConvert.SerializeObject(domainEvent));
        }
    }
}
