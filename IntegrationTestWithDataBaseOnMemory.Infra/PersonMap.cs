using FluentNHibernate.Mapping;
using IntegrationTestWithDataBaseOnMemory.Domain;

namespace IntegrationTestWithDataBaseOnMemory.Infra
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Email);
        }
    }
}