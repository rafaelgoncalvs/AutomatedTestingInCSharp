using System.Collections.Generic;

namespace AutomatedTestingInCSharp.Domain
{
    public interface PeopleRepository
    {
        IEnumerable<Person> GetAll();
        void Add(Person person);
    }
}