using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SampleApplication.Core.Domain.People;
using SampleApplication.Framework;

namespace SampleApplication.Infra.Data
{
    public class EFDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=. ; initial catalog = MicroService ; Trusted_connection = true");
        }
        public override int SaveChanges()
        {
            HandelBeforeSaveChanges();
            return base.SaveChanges();
        }

        private void HandelBeforeSaveChanges()
        {
            DispatchEvents();
        }

        private void DispatchEvents()
        {
            var dispatcher = this.GetService<IDomainEventDispatcher>();
            var entities = ChangeTracker.Entries<Entity<long>>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
                .Select(c => c.Entity).ToList();
            foreach (var entity in entities)
            {
                dispatcher.Dispatch(entity.Events);
                entity.ClearEvent();
            }
        }
    }
}