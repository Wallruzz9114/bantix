using Data.Entities;
using FluentValidation;
using Libraries.Abstraction.Validations;

namespace Data.Validations
{
    public class CustomerFieldValidation : EntityValidator<Customer>
    {
        public CustomerFieldValidation(Customer customer) : base(customer)
        {
            RuleFor(c => c.FullName)
                .NotEmpty().WithMessage("The full name is required.")
                .MaximumLength(50).WithMessage("The full name cannot be bigger than 300 characters.");

            RuleFor(c => c.Identifier)
                .NotEmpty().WithMessage("The identifier is required.");

            RuleFor(c => c.DateOfBirth)
                .NotEmpty().WithMessage("The date of birth is req");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("The email is required.")
                .EmailAddress().WithMessage("The email is invalid.");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("The phone number is required.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("The password is required.");

            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("The user status is required.");
        }
    }
}