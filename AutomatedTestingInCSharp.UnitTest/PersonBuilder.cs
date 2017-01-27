using AutomatedTestingInCSharp.Domain;

namespace AutomatedTestingInCSharp.UnitTest
{
    public class PersonBuilder
    {
        private string _name;
        private string _email;

        public PersonBuilder()
        {
            _name = "Test Person";
            _email = "test@test.com";
        }

        public static PersonBuilder New()
        {
            return new PersonBuilder();
        }

        public PersonBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public PersonBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public Person Build()
        {
            return new Person(_name, _email);
        }
    }
}