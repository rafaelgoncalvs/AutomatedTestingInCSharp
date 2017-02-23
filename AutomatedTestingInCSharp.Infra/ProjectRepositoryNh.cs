using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.Infra.Base;
using NHibernate;

namespace AutomatedTestingInCSharp.Infra
{
    public class ProjectRepositoryNh : RepositoryNh<Project>, ProjectRepository
    {
        public ProjectRepositoryNh(ISession session) : base(session)
        {
        }
    }
}
