using Microsoft.EntityFrameworkCore;
using SampleApplication.Core.ApplicationService.Customers;
using SampleApplication.Core.Domain.People;

namespace SampleApplication.Infra.Data.SQL
{
    public class EFPersonRepository : CustomerRepository
    {
        public EFPersonRepository(EFDBContext context)
        {
            Context = context;
        }

        public EFDBContext Context { get; }

        public void Add(Customer peson)
        {
            Context.People.Add(peson);
            Context.SaveChanges();
        }

        public Customer? Find(long personId)
        {
            return Context.People.Include(x => x.PhoneNumbers).SingleOrDefault(x => x.Id == personId);
        }

        public void Update()
        {
            Context.SaveChanges();
        }
    }
}
