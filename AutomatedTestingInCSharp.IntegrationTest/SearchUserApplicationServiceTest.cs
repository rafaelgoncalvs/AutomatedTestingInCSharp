using System.Linq;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;
using AutomatedTestingInCSharp.UnitTest;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    [TestFixture]
    public class SearchUserApplicationServiceTest : IntegrationTestBase
    {
        private SearchUserApplicationService _searchUserApplicationService;
        private UserPersist _userPersist;

        [SetUp]
        public void SetUp()
        {
            _searchUserApplicationService = GetInstance<SearchUserApplicationService>();
            _userPersist = GetInstance<UserPersist>();
        }

        [Test]
        public void Should_search_users()
        {
            var user1 = UserBuilder.New().WithName("User 1").Build();
            var user2 = UserBuilder.New().WithEmail("person@teste.com").Build();
            _userPersist.Add(user1);
            _userPersist.Add(user2);

            var userDtos = _searchUserApplicationService.Search();

            Assert.IsTrue(userDtos.Any(person => user1.Email == person.Email && user1.Name == person.Name));
            Assert.IsTrue(userDtos.Any(person => user2.Email == person.Email && user2.Name == person.Name));
        }
    }
}
