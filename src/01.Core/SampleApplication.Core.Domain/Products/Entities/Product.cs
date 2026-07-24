using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.Products.Entities
{
    public class Product : AggregateRoot<long>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Discount Discount { get; set; }
        public long CategoryId{ get; set; }
        public void SetDiscount(int discountAmount)
        {
            if (Price - discountAmount < 0)
                throw new ArgumentException("Invalid value for discount amount");
            Discount = new Discount
            {
                Amount = discountAmount
            };
        }
    }
}
