using SampleApplication.Core.Domain.Orders.Entities;
using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.Orders
{
    public interface IOrderRerpository : ICommandRepository<Order,long>
    {
    }
}
