using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.UnitTest.Base;

namespace AutomatedTestingInCSharp.UnitTest
{
    public class TeamBuilder : Builder<Team>
    {
        public TeamBuilder()
        {
            With(team => team.Name, "Team Name");
            WithCollection(team => team.Projects, ProjectBuilder.New().Build());
            WithCollection(team => team.Members, 
                MemberBuilder.New().With(m => m.Role, Role.ScrumMaster).Build(), 
                MemberBuilder.New().With(m => m.Role, Role.ProductOwner).Build(),
                MemberBuilder.New().With(m => m.Role, Role.Developer).Build());
        }

        public static TeamBuilder New()
        {
            return new TeamBuilder();
        }
    }
}