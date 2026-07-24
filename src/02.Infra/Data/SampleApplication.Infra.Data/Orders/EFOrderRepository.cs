using SampleApplication.Core.Domain.Orders;
using SampleApplication.Core.Domain.Orders.Entities;
using SampleApplication.Framework;

namespace SampleApplication.Infra.Data.SQL.Orders
{
    public class EFOrderRepository : EFCommandRepository<Order, long, EFDBContext>, IOrderRerpository
    {
        public EFOrderRepository(EFDBContext dbContext) : base(dbContext)
        {
        }
    }
}
