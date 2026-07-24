using SampleApplication.Core.Domain.Categories.Events;
using SampleApplication.Framework;

namespace SampleApplication.Core.Domain.Categories
{
    public class Category : AggregateRoot<long>
    {
        public string Title { get; private set; }
        public Category(string title)
        {
            Title = title;
            AddEvent(new CategoryCreated(title));
        }
    }
}
