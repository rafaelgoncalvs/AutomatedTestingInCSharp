using AutomatedTestingInCSharp.Domain;
using FluentNHibernate.Mapping;

namespace AutomatedTestingInCSharp.Infra
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(project => project.Id);
            Map(project => project.Name).Not.Nullable();
            References(project => project.Client).Not.Nullable().Cascade.All();
        }
    }
}
