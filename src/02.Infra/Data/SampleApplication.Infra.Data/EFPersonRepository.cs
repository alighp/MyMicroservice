using Microsoft.EntityFrameworkCore;
using SampleApplication.Core.ApplicationService;
using SampleApplication.Core.Domain.People;

namespace SampleApplication.Infra.Data.SQL
{
    public class EFPersonRepository : PersonRepository
    {
        public EFPersonRepository(EFDBContext context)
        {
            Context = context;
        }

        public EFDBContext Context { get; }

        public void Add(Person peson)
        {
            Context.People.Add(peson);
            Context.SaveChanges();
        }

        public Person? Find(long personId)
        {
            return Context.People.Include(x => x.PhoneNumbers).SingleOrDefault(x => x.Id == personId);
        }

        public void Update()
        {
            Context.SaveChanges();
        }
    }
}
