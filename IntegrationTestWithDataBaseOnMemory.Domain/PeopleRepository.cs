using System.Collections.Generic;

namespace IntegrationTestWithDataBaseOnMemory.Domain
{
    public interface PeopleRepository
    {
        IEnumerable<Person> GetAll();
        void Add(Person person);
    }
}