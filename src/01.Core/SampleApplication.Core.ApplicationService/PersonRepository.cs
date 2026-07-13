using SampleApplication.Core.Domain.People;

namespace SampleApplication.Core.ApplicationService
{
    public interface PersonRepository
    {
        public void Add(Person peson);
        Person? Find(long personId);
        public void Update();
    }
}