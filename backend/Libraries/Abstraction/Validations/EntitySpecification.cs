using Libraries.Abstraction.Models;

namespace Libraries.Abstraction.Validations
{
    public abstract class EntitySpecification<T> where T : Entity<T>
    {
        protected readonly T _entity;

        protected EntitySpecification(T entity)
        {
            _entity = entity;
        }

        public abstract bool IsValid();
    }
}