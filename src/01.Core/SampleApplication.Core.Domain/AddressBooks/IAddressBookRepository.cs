using SampleApplication.Core.Domain.AddressBooks.Entities;
using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.AddressBooks
{
    public interface IAddressBookRepository : ICommandRepository<AddressBook, long>
    {
    }
}
