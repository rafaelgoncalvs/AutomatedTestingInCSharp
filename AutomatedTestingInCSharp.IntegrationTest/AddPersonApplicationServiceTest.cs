using System.Linq;
using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Domain;
using NUnit.Framework;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    [TestFixture]
    public class AddPersonApplicationServiceTest : IntegrationTestBase
    {
        private AddPersonApplicationService _addPersonApplicationSercice;
        private PeopleRepository _peopleRepository;

        [SetUp]
        public void SetUp()
        {
            _addPersonApplicationSercice = GetInstance<AddPersonApplicationService>();
            _peopleRepository = GetInstance<PeopleRepository>();
        }
        
        [Test]
        public void Should_add_a_person()
        {
            const string email = "rafael@test.com";
            const string name = "Rafael";
            var adicionaPessoaDto = new AddPersonDto { Email = email, Name = name };

            _addPersonApplicationSercice.Add(adicionaPessoaDto);

            var people = _peopleRepository.GetAll().ToArray();
            var person = people[0];

            Assert.True(people.Length == 1);
            Assert.AreEqual(adicionaPessoaDto.Email, person.Email);
            Assert.AreEqual(adicionaPessoaDto.Name, person.Name);
        }
        
        [Test]
        public void Should_not_find_anyone()
        {
            var people = _peopleRepository.GetAll().ToArray();
         
            Assert.True(people.Length == 0);
        }
    }
}
