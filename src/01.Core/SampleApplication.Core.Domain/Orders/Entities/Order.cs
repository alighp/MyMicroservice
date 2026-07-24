using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.Orders.Entities
{
    public class Order : AggregateRoot<long>
    {
        private Order()
        {

        }
        public Order(long addressLineId, DateTime orderDate, List<OrderLine> orderLines)
        {
            if (!orderLines.Any())
                throw new ArgumentException();

            OrderDate = orderDate;
            _orderLines = orderLines;
            AddressLineId = addressLineId;

        }
        public long AddressLineId { get; set; }
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        private readonly List<OrderLine> _orderLines = new();
        public IReadOnlyList<OrderLine> OrderLines => _orderLines;
        public void SetCount(int newCount, long orderLineId)
        {
            if (newCount < 0)
                throw new ArgumentException("orderLine Count cant be negetive");

            var orderLine = _orderLines.SingleOrDefault(x => x.Id == orderLineId);
            if (orderLine == null)
                throw new ArgumentException("orderLine not found");

            orderLine.SetCount(newCount);
        }

        public int GetTotatPrice() => _orderLines.Sum(x => x.GetTotalPrice());

    }
}
