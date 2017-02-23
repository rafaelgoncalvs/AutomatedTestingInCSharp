using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.UnitTest.Base;

namespace AutomatedTestingInCSharp.UnitTest
{
    public class ClientBuilder : Builder<Client>
    {
        public ClientBuilder()
        {
            With(c => c.Name, "Client name test");
        }

        public static ClientBuilder New()
        {
            return new ClientBuilder();
        }
    }
}