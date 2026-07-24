using SampleApplication.Core.Domain.Products;
using SampleApplication.Core.Domain.Products.Entities;
using SampleApplication.Framework;

namespace SampleApplication.Infra.Data.SQL.Products
{
    public class EFProductRepository : EFCommandRepository<Product, long, EFDBContext>, IProductRepository
    {
        public EFProductRepository(EFDBContext dbContext) : base(dbContext)
        {
        }
    }
}
