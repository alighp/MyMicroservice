using Microsoft.EntityFrameworkCore;
using SampleApplication.Core.Domain.AddressBooks.Entities;
using SampleApplication.Core.Domain.Categories;
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
        public DbSet<Category> Categories { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // پیکربندی PhoneNumber به عنوان Owned Type
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.OwnsMany(c => c.PhoneNumbers, phone =>
                {
                    phone.WithOwner().HasForeignKey("CustomerId");
                    phone.ToTable("CustomerPhoneNumbers");

                    phone.Property(p => p.Number)
                        .HasColumnName("PhoneNumber")
                        .HasMaxLength(20)
                        .IsRequired();

                    phone.Property(p => p.Type)
                        .HasColumnName("PhoneType")
                        .HasConversion<int>();
                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}