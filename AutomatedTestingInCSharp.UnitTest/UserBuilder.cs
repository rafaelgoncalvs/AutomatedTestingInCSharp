using AutomatedTestingInCSharp.Domain;

namespace AutomatedTestingInCSharp.UnitTest
{
    public class UserBuilder
    {
        private string _name;
        private string _email;

        public UserBuilder()
        {
            _name = "User Test";
            _email = "test@test.com";
        }

        public static UserBuilder New()
        {
            return new UserBuilder();
        }

        public UserBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public User Build()
        {
            return new User(_name, _email);
        }
    }
}