namespace AutomatedTestingInCSharp.Domain
{
    public interface Repository<T> where T : Entity<T>
    {
        void Add(T entity);
        void Update(T entity);
        T Get(int id);
    }
}
