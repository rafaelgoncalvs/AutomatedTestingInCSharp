using AutomatedTestingInCSharp.Domain;
using AutomatedTestingInCSharp.IntegrationTest.Base;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    public class ClientPersist : Persist<Client>
    {
        public ClientPersist(ClientRepository clientRepository) : base(clientRepository)
        {
        }
    }
}