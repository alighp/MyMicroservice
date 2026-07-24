namespace SampleApplication.Core.Domain.AddressBooks.Entities
{
    public class AddressLine : Entity<long>
    {
        public long AddressBookId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public bool IsDefault { get; set; }
        public string PostalCode { get; set; }

        public AddressLine(string street, string city, string state,
                       string postalCode, bool isDefault)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street is required", nameof(street));
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City is required", nameof(city));
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("Postal code is required", nameof(postalCode));

            Street = street.Trim();
            City = city.Trim();
            State = state?.Trim() ?? string.Empty;
            PostalCode = postalCode.Trim();
            IsDefault = isDefault;
        }
        public override string ToString()
        => string.IsNullOrEmpty(State)
            ? $"{Street}, {City}"
            : $"{Street}, {City}, {State}";
    }

}
