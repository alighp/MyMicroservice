namespace SampleApplication.Core.Domain.Orders
{
    public class OrderLine : Entity<long>
    {
        public long ProductId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }

        public void SetCount(int newCount)
        {
            if (newCount < 0)
                throw new ArgumentException("orderLine Count cant be negetive");
        }

        public int GetTotalPrice() => Count * Price;
    }
}
