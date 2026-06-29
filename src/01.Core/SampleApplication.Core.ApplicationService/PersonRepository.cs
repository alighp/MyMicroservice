using SampleApplication.Core.Domain;

namespace SampleApplication.Core.ApplicationService
{
    public interface PersonRepository
    {
        public void Add(Person peson);
        Person? Find(int personId);
        public void Update();
    }
}