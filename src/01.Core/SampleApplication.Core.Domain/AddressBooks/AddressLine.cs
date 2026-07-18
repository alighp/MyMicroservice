namespace SampleApplication.Core.Domain.AddressBooks
{
    public class AddressLine
    {
        public long Id { get; set; }
        public long AddressBookId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool IsDefault { get; set; }

    }
}
