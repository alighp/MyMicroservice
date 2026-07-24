using SampleApplication.Core.Domain.Products.Entities;
using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.Products
{
    public interface IProductRepository : ICommandRepository<Product, long>
    {
    }
}
