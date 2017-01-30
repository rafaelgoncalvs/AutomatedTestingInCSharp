using System;
using NHibernate;

namespace AutomatedTestingInCSharp.Infra.Base
{
    public abstract class RepositoryNh<TEntidade> where TEntidade : class
    {
        protected readonly ISession _session;

        protected RepositoryNh(ISession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            _session = session;
        }

        public void Add(TEntidade entity)
        {
            _session.Save(entity);
        }

        public void Update(TEntidade entity)
        {
            _session.Update(entity);
        }

        public TEntidade Get(int id)
        {
            return _session.Get<TEntidade>(id);
        }
    }
}