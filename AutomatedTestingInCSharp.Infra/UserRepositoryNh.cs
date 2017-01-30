using System.Collections.Generic;
using System.Linq;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.Infra.Base;
using NHibernate;
using NHibernate.Linq;

namespace AutomatedTestingInCSharp.Infra
{
    public class UserRepositoryNh : RepositoryNh<User>, UserRepository
    {
        public UserRepositoryNh(ISession session) : base(session)
        {
        }

        public IEnumerable<User> GetAll()
        {
            return _session.Query<User>().CacheMode(CacheMode.Normal).ToList();
        }
    }
}