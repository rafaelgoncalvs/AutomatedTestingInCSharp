using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.Infra.Base;
using NHibernate;

namespace AutomatedTestingInCSharp.Infra
{
    public class ClientRepositoryNh : RepositoryNh<Client>, ClientRepository
    {
        public ClientRepositoryNh(ISession session) : base(session)
        {
        }
    }
}
