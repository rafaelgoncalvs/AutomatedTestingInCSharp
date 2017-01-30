using System.Linq;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    [TestFixture]
    public class AddUserApplicationServiceTest : IntegrationTestBase
    {
        private AddUserApplicationService _addUserApplicationSercice;
        private UserRepository _userRepository;

        [SetUp]
        public void SetUp()
        {
            _addUserApplicationSercice = GetInstance<AddUserApplicationService>();
            _userRepository = GetInstance<UserRepository>();
        }
        
        [Test]
        public void Should_add_an_user()
        {
            const string email = "rafael@test.com";
            const string name = "Rafael";
            var addUserDto = new AddUserDto { Email = email, Name = name };

            _addUserApplicationSercice.Add(addUserDto);

            var people = _userRepository.GetAll().ToArray();
            var person = people[0];

            Assert.True(people.Length == 1);
            Assert.AreEqual(addUserDto.Email, person.Email);
            Assert.AreEqual(addUserDto.Name, person.Name);
        }
    }
}
