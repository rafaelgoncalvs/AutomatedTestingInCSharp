using System.Collections.Generic;
using System.Linq;
using IntegrationTestWithDataBaseOnMemory.Domain;
using NHibernate;
using NHibernate.Linq;

namespace IntegrationTestWithDataBaseOnMemory.Infra
{
    public class PeopleRepositoryNh : PeopleRepository
    {
        private readonly ISession _session;
        
        public PeopleRepositoryNh(ISession session)
        {
            _session = session;
        }

        public IEnumerable<Person> GetAll()
        {
            return _session.Query<Person>().CacheMode(CacheMode.Normal).ToList();
        }

        public void Add(Person person)
        {
            _session.Save(person);
        }
    }
}