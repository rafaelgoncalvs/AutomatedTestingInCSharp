using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.Infra.Base;
using NHibernate;

namespace AutomatedTestingInCSharp.Infra
{
    public class TeamRepositoryNh : RepositoryNh<Team>, TeamRepository
    {
        public TeamRepositoryNh(ISession session) : base(session)
        {
        }
    }
}
