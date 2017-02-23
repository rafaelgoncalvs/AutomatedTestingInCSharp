using AutomatedTestingInCSharp.Domain;
using FluentNHibernate.Mapping;

namespace AutomatedTestingInCSharp.Infra
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Id(client => client.Id);
            Map(client => client.Name).Not.Nullable();
        }
    }
}
