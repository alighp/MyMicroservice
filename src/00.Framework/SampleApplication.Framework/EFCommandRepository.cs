namespace SampleApplication.Framework
{
    public class EFCommandRepository<TAggregate, TId, TDbContext> : ICommandRepository<TAggregate, TId>
        where TAggregate : AggregateRoot<TId>
        where TDbContext : BaseCommandDBContext
    {
        protected readonly TDbContext DbContext;
        public EFCommandRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }


        public TAggregate Get(TId id)
        {
            return DbContext.Set<TAggregate>().First(x => x.Id!.Equals(id));
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
