using Newtonsoft.Json;
using SampleApplication.Core.Domain.Customers.Events;
using SampleApplication.Framework;

namespace SampleApplication.Core.ApplicationService.Customers.EventHandlers
{
    public class WriteCustomerCreatedToConsole : IDomainEventHandler<CustomerCreated>
    {
        public Task Handle(CustomerCreated domainEvent)
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
