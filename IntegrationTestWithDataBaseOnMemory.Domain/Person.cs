namespace IntegrationTestWithDataBaseOnMemory.Domain
{
    public class Person
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Email { get; protected set; }

        protected Person() { }

        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
