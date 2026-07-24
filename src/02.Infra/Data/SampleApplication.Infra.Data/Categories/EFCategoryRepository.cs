using SampleApplication.Core.Domain.Categories;
using SampleApplication.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Infra.Data.SQL.Categories
{
    public class EFCategoryRepository : EFCommandRepository<Category, long, EFDBContext>, ICategoryRepository

    {
        public EFCategoryRepository(EFDBContext dbContext) : base(dbContext)
        {
        }

        public void Add(Category category)
        {
            DbContext.Categories.Add(category);
        }

        public Category? Find(long categoryId)
        {
            return DbContext.Categories.SingleOrDefault(x => x.Id == categoryId);

        }
    }
}
