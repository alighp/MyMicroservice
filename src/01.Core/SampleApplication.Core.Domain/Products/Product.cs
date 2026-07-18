namespace SampleApplication.Core.Domain.Products
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Discount Discount { get; set; }
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
