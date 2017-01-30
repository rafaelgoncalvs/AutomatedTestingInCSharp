using NUnit.Framework;

namespace AutomatedTestingInCSharp.UnitTest
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void Should_create_an_user()
        {
            const string name = "Rafael";
            const string email = "rafael@test.com";
            
            var person = UserBuilder.New().WithName(name).WithEmail(email).Build();

            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(email, person.Email);
        }
    }
}
