using System.Collections.Specialized;
using AutomatedTestingInCSharp.Domain;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.UnitTest
{
    [TestFixture]
    public class PersonTest
    {
        [Test]
        public void Should_create_a_person()
        {
            const string name = "Rafael";
            const string email = "rafael@test.com";
            
            var person = PersonBuilder.New().WithName(name).WithEmail(email).Build();

            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(email, person.Email);
        }
    }

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
