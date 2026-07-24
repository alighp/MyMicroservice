namespace SampleApplication.Framework
{
    public interface IUnitOfWork 
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
