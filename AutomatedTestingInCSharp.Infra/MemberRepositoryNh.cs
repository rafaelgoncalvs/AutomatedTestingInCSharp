using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.Infra.Base;
using NHibernate;

namespace AutomatedTestingInCSharp.Infra
{
    public class MemberRepositoryNh : RepositoryNh<Member>, MemberRepository
    {
        public MemberRepositoryNh(ISession session) : base(session)
        {
        }
    }
}