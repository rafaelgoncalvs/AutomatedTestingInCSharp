using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.UnitTest.Base;

namespace AutomatedTestingInCSharp.UnitTest
{
    public class TeamBuilder : Builder<Team>
    {
        public TeamBuilder()
        {
            With(team => team.Name, "Team Name");
        }

        public static TeamBuilder New()
        {
            return new TeamBuilder();
        }
    }
}