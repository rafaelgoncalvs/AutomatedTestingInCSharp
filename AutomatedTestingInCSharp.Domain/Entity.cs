namespace AutomatedTestingInCSharp.Domain
{
    public abstract class Entity<T> where T : Entity<T>
    {
        public virtual int Id { get; protected set; }

        public virtual bool IsTransiente
        {
            get { return Id == 0; }
        }

        public override bool Equals(object obj)
        {
            var anotherEntity = obj as T;
            if (anotherEntity == null) return false;

            if (IsTransiente && anotherEntity.IsTransiente)
                return ReferenceEquals(this, anotherEntity);

            return Id == anotherEntity.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Entity<T> e1, Entity<T> e2)
        {
            return Equals(e1, e2);
        }

        public static bool operator !=(Entity<T> e1, Entity<T> e2)
        {
            return !Equals(e1, e2);
        }
    }
}