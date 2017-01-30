using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;
using NHibernate.Util;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    public class UserPersist : Persist<User>
    {
        private readonly TeamPersist _temPersist;

        public UserPersist(UserRepository userRepository, TeamPersist temPersist) : base(userRepository)
        {
            _temPersist = temPersist;
        }

        protected override void AddDependentEntities(User user)
        {
            user.Teams.ForEach(team => _temPersist.Add(team));
        }
    }
}