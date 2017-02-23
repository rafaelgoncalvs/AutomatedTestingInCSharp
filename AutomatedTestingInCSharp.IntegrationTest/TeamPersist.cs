using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;
using NHibernate.Util;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    public class TeamPersist : Persist<Team>
    {
        private readonly MemberPersist _memberPersist;
        private readonly ProjectPersist _projectPersist;

        public TeamPersist(TeamRepository teamRepository, MemberPersist memberPersist, ProjectPersist projectPersist) : base(teamRepository)
        {
            _memberPersist = memberPersist;
            _projectPersist = projectPersist;
        }

        protected override void AddDependentEntities(Team team)
        {
            team.Members.ForEach(member => _memberPersist.Add(member));
            team.Projects.ForEach(project => _projectPersist.Add(project));
        }
    }
}