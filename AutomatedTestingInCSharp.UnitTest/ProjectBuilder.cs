using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.UnitTest.Base;

namespace AutomatedTestingInCSharp.UnitTest
{
    public class ProjectBuilder : Builder<Project>
    {
        public ProjectBuilder()
        {
            With(p => p.Name, "Project name test");
            With(p => p.Client, ClientBuilder.New().Build());
        }

        public static ProjectBuilder New()
        {
            return new ProjectBuilder();
        }
    }
}