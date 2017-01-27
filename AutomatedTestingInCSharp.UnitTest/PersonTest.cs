using System.Collections.Specialized;
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
}
