using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    public class TeamPersist : Persist<Team>
    {
        public TeamPersist(TeamRepository teamRepository) : base(teamRepository)
        {
        }
    }
}