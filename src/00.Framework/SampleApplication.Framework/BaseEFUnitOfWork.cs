namespace SampleApplication.Framework
{
    public class BaseEFUnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : BaseCommandDBContext
    {
        private readonly TDbContext DbContext;
        public BaseEFUnitOfWork(TDbContext dBContext)
        {
            DbContext = dBContext;
        }


        public void Begin()
        {
            DbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            DbContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            DbContext.Database.RollbackTransaction();
        }
    }
}
