namespace SampleApplication.Core.Domain.AddressBooks
{
    public class AddressBook
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        private readonly List<AddressLine> _addressLines = new();
        public IReadOnlyList<AddressLine> AddressLines => _addressLines;
        public AddressLine GetDefault() => AddressLines.Single(x => x.IsDefault);
        public void AddAddressLine(string address, string city, bool isDefault)
        {
            if (isDefault)
            {
                _addressLines.ForEach(x => x.IsDefault = false);
            }
            var addressLine = new AddressLine
            {
                Address = address,
                City = city,
                IsDefault = isDefault
            };
            _addressLines.Add(addressLine);
        }

    }

}
