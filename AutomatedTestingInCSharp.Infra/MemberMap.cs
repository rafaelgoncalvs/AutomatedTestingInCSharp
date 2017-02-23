using AutomatedTestingInCSharp.Domain;
using FluentNHibernate.Mapping;

namespace AutomatedTestingInCSharp.Infra
{
    public class MemberMap : ClassMap<Member>
    {
        public MemberMap()
        {
            Id(member => member.Id);
            Map(member => member.Name).Not.Nullable();
            Map(member => member.Email).Not.Nullable();
            Map(member => member.Role).Not.Nullable();
        }
    }
}