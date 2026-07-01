namespace SampleApplication.Core.Domain
{
    public class PhoneNumber 
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public PhoneNumber()
        {

        }
        public PhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentNullException("Invalid input for phoneNumber");
            }
            Number = phoneNumber;
        }
    }
}