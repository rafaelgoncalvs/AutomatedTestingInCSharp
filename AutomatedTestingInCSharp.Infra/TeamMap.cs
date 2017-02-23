using AutomatedTestingInCSharp.Domain;
using FluentNHibernate.Mapping;

namespace AutomatedTestingInCSharp.Infra
{
    public class TeamMap : ClassMap<Team>
    {
        public TeamMap()
        {
            Id(team => team.Id);
            Map(team => team.Name).Not.Nullable();
            HasMany(team => team.Members).Cascade.AllDeleteOrphan();
            HasMany(team => team.Projects).Cascade.AllDeleteOrphan();
        }
    }
}
