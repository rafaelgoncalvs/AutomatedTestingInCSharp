using AutomatedTestingInCSharp.Domain;
using FluentNHibernate.Mapping;

namespace AutomatedTestingInCSharp.Infra
{
    public class TeamMap : ClassMap<Team>
    {
        public TeamMap()
        {
            Id(user => user.Id);
            Map(user => user.Name);
        }
    }
}
