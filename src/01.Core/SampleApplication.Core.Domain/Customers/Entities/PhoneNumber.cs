using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.Customers.Entities
{
    public class PhoneNumber : ValueObject
    {
        public string Number { get; }
        public PhoneNumberType Type { get; } // مثلاً: Mobile, Home, Work
        private PhoneNumber()
        {

        }
        public PhoneNumber(string number, PhoneNumberType type = PhoneNumberType.Mobile)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Phone number cannot be empty", nameof(number));

            // اعتبارسنجی فرمت شماره
            if (!IsValidPhoneNumber(number))
                throw new ArgumentException("Invalid phone number format", nameof(number));

            Number = number;
            Type = type;
        }

        private bool IsValidPhoneNumber(string number)
        {
            // منطق اعتبارسنجی شماره تلفن
            // مثلاً: Regex برای شماره ایران
            return !string.IsNullOrWhiteSpace(number) && number.Length >= 10;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
            yield return Type;
        }

        // متدهای کمکی
        public override string ToString() => Number;

        // implicit conversion برای سهولت استفاده
        public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Number;
        public static explicit operator PhoneNumber(string number) => new PhoneNumber(number);
    }

    public enum PhoneNumberType
    {
        Mobile,
        Home,
        Work,
        Fax
    }
}