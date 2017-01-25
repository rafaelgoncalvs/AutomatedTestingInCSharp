using AutomatedTestingInCSharp.Domain;
using FluentNHibernate.Mapping;

namespace AutomatedTestingInCSharp.Infra
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