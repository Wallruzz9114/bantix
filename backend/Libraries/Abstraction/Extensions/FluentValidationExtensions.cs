using Libraries.Abstraction.Models;
using Libraries.Abstraction.Validations;
using FluentValidation;

namespace Libraries.Abstraction.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> IsValid<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, EntitySpecification<T> predicate) where T : Entity<T>
        {
            return ruleBuilder.Must(p => predicate.IsValid());
        }
    }
}