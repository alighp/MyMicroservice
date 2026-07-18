using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using SampleApplication.Core.Domain.People;
using SampleApplication.Framework;

namespace SampleApplication.Infra.Data
{
    public class EFDBContext : DbContext
    {
        public DbSet<Customer> People { get; set; }
        public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
        }
        public override int SaveChanges()
        {
            HandelBeforeSaveChanges();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        private void HandelBeforeSaveChanges()
        {
            AddToOutBox();
            DispatchEvents();
        }

        private void AddToOutBox()
        {
            var entities = ChangeTracker.Entries<Entity<long>>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
                .Select(c => c.Entity).ToList();
            var now = DateTime.Now;
            foreach (var entity in entities)
            {
                foreach (var @event in entity.Events)
                {
                    OutBoxEventItems.Add(new OutBoxEventItem
                    {
                        EventId = Guid.NewGuid(),
                        AccuredByUserId = "Ali",
                        AccuredOn = now,
                        AggregateId = "1",
                        AggregateName = @event.GetType().Name,
                        AggregateTypeName = @event.GetType().FullName,
                        EventName = @event.GetType().Name,
                        EventTypeName = @event.GetType().FullName,
                        EventPayLoad = JsonConvert.SerializeObject(@event),
                        IsProcessed = false
                    });
                }
            }
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