using SampleApplication.Core.Domain.People;

namespace SampleApplication.Core.ApplicationService.Customers
{
    public interface CustomerRepository
    {
        public void Add(Customer peson);
        Customer? Find(long personId);
        public void Update();
    }
}