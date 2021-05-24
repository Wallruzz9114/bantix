using Libraries.Abstraction.Interfaces;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Libraries.Abstraction.Models
{
    public abstract class Entity<T> : IEntity where T : Entity<T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; protected set; }

        public abstract bool IsValid();

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        public void NewValidationResult(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public void AddErrorValidation(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b) => !(a == b);

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 451) + Id.GetHashCode();
        }
    }
}