using Microsoft.EntityFrameworkCore;
using SampleApplication.Core.Domain.Customers;
using SampleApplication.Core.Domain.Customers.Entities;
using SampleApplication.Framework;

namespace SampleApplication.Infra.Data.SQL.Customers
{
    public class EFCusomerRepository : EFCommandRepository<Customer, long, EFDBContext>, ICustomerRepository
    {
        public EFDBContext Context { get; }
        public EFCusomerRepository(EFDBContext dbContext) : base(dbContext)
        {
        }

        public void Add(Customer peson)
        {
            Context.Customers.Add(peson);
        }

        public Customer? Find(long personId)
        {
            return Context.Customers.Include(x => x.PhoneNumbers).SingleOrDefault(x => x.Id == personId);
        }


    }
}
