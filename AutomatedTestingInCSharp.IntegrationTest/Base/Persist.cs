using AutomatedTestingInCSharp.Domain;

namespace AutomatedTestingInCSharp.IntegrationTest.Base
{
    public abstract class Persist<TEntity> where TEntity : Entity<TEntity>
    {
        private readonly Repository<TEntity> _repository;

        protected Persist(Repository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            AddDependentEntities(entity);
            _repository.Add(entity);
        }

        protected virtual void AddDependentEntities(TEntity entity)
        {
        }
    }
}