using System.Collections.Generic;
using System.Linq;
using AutomatedTestingInCSharp.Domain;
using NHibernate;
using NHibernate.Linq;

namespace AutomatedTestingInCSharp.Infra
{
    public class UserRepositoryNh : UserRepository
    {
        private readonly ISession _session;
        
        public UserRepositoryNh(ISession session)
        {
            _session = session;
        }

        public IEnumerable<User> GetAll()
        {
            return _session.Query<User>().CacheMode(CacheMode.Normal).ToList();
        }

        public void Add(User user)
        {
            _session.Save(user);
        }
    }
}