using Microsoft.EntityFrameworkCore;
using SampleApplication.Core.Domain.AddressBooks.Entities;
using SampleApplication.Core.Domain.Customers.Entities;
using SampleApplication.Core.Domain.Orders.Entities;
using SampleApplication.Core.Domain.Products.Entities;
using SampleApplication.Framework;

namespace SampleApplication.Infra.Data.SQL
{
    public class EFDBContext : BaseCommandDBContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AddressBook> AddressBooks { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
        }
    }
}