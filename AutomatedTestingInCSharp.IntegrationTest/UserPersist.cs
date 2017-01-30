using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    public class UserPersist : Persist<User>
    {
        public UserPersist(UserRepository userRepository) : base(userRepository)
        {
        }
    }
}