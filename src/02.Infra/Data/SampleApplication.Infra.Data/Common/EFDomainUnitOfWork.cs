using SampleApplication.Core.Domain.Common;
using SampleApplication.Framework;

namespace SampleApplication.Infra.Data.SQL.Common
{
    public class EFDomainUnitOfWork : BaseEFUnitOfWork<EFDBContext>, IDomainUnitOfWork
    {
        public EFDomainUnitOfWork(EFDBContext dBContext) : base(dBContext)
        {
        }
    }
}
    