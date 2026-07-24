using SampleApplication.Core.Domain.Categories;

namespace SampleApplication.Core.ApplicationService.Categoreis
{
    public class CategoryAppService
    {
        private readonly ICategoryRepository repository;

        public CategoryAppService(ICategoryRepository repository)
        {
            this.repository = repository;
        }
        public void Add(CreateCategoryDto dto)
        {
            var category = new Category(dto.Title);
            repository.Add(category);
            repository.SaveChanges();
        }
    }
}
