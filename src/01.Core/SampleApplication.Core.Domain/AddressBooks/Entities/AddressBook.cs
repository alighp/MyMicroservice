using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.AddressBooks.Entities
{
    public class AddressBook : AggregateRoot<long>
    {
        public long CustomerId { get; set; }
        private readonly List<AddressLine> _addressLines = new();
        public IReadOnlyList<AddressLine> AddressLines => _addressLines;
        public AddressLine GetDefault() => AddressLines.Single(x => x.IsDefault);
        public void AddAddressLine(string street, string city, string state, string postalCode, bool isDefault)
        {
            if (isDefault)
            {
                _addressLines.ForEach(x => x.IsDefault = false);
            }
            var addressLine = new AddressLine(street, city, state, postalCode, isDefault);
            _addressLines.Add(addressLine);
        }

    }

}
