using Libraries.Abstraction.Models;
using FluentValidation;

namespace Libraries.Abstraction.Validations
{
    public abstract class EntityValidator<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected readonly T _entity;

        public EntityValidator(T entity)
        {
            _entity = entity;
        }
    }
}