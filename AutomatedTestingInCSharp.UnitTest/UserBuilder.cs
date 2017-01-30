using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.UnitTest.Base;

namespace AutomatedTestingInCSharp.UnitTest
{
    public class UserBuilder : Builder<User>
    {
        public UserBuilder()
        {
            With(user => user.Name, "User Test");
            With(user => user.Email, "test@test.com");
        }

        public static UserBuilder New()
        {
            return new UserBuilder();
        }
    }
}