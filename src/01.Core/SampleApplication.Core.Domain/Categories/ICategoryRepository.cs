using SampleApplication.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Core.Domain.Categories
{
    public interface ICategoryRepository : ICommandRepository<Category, long>
    {
        public void Add(Category category);
        public Category? Find(long categoryId);
    }
}
