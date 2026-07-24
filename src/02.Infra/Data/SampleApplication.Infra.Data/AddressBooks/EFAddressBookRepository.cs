using SampleApplication.Core.Domain.AddressBooks;
using SampleApplication.Core.Domain.AddressBooks.Entities;
using SampleApplication.Framework;

namespace SampleApplication.Infra.Data.SQL.AddressBooks
{
    public class EFAddressBookRepository : EFCommandRepository<AddressBook, long, EFDBContext>, IAddressBookRepository
    {
        public EFAddressBookRepository(EFDBContext dbContext) : base(dbContext)
        {
        }
    }
}
