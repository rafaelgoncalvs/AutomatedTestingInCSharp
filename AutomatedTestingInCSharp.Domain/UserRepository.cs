using System.Collections.Generic;

namespace AutomatedTestingInCSharp.Domain
{
    public interface UserRepository : Repository<User>
    {
        IEnumerable<User> GetAll();
    }
}