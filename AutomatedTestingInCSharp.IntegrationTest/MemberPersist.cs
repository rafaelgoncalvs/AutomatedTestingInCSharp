using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;
using NHibernate.Util;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    public class MemberPersist : Persist<Member>
    {
        public MemberPersist(MemberRepository memberRepository) : base(memberRepository)
        {
        }
    }
}