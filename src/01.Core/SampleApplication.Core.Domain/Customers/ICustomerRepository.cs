using SampleApplication.Core.Domain.Customers.Entities;
using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.Customers
{
    public interface ICustomerRepository : ICommandRepository<Customer, long>
    {
        public void Add(Customer peson);
        public Customer? Find(long personId);
    }
}
