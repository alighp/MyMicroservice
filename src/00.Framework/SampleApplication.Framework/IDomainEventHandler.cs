using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Framework
{
    public interface IDomainEventHandler<TDomainEvent> where  TDomainEvent : IDomainEvent 
    {
        Task Handle(TDomainEvent domainEvent); 
    }
}
