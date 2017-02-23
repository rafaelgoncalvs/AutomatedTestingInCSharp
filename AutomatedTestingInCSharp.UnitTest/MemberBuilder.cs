using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.UnitTest.Base;

namespace AutomatedTestingInCSharp.UnitTest
{
    public class MemberBuilder : Builder<Member>
    {
        public MemberBuilder()
        {
            With(member => member.Name, "Member Name Test");
            With(member => member.Email, "test@test.com");
            With(member => member.Role, Role.Developer);
        }

        public static MemberBuilder New()
        {
            return new MemberBuilder();
        }
    }
}