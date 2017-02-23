using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    public class ProjectPersist : Persist<Project>
    {
        private readonly ClientPersist _clientPersist;

        public ProjectPersist(ProjectRepository projectRepository, ClientPersist clientPersist) : base(projectRepository)
        {
            _clientPersist = clientPersist;
        }

        protected override void AddDependentEntities(Project project)
        {
            _clientPersist.Add(project.Client);
        }
    }
}