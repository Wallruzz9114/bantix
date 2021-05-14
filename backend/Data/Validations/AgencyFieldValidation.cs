using Data.Entities;
using FluentValidation;
using Libraries.Abstraction.Validations;

namespace Data.Validations
{
    public class AgencyFieldValidation : EntityValidator<Agency>
    {
        public AgencyFieldValidation(Agency agency) : base(agency)
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Please enter an id.");

            RuleFor(a => a.FullName)
                .NotEmpty().WithMessage("Please enter an full name.")
                .MaximumLength(100).WithMessage("The agency name cannot exceed 100 characters.");

            RuleFor(a => a.DisplayName)
                .NotEmpty().WithMessage("Please enter a display name.")
                .MaximumLength(50).WithMessage("The display name cannot exceed 50 characters.");

            RuleFor(a => a.BusinessId)
                .NotEmpty().WithMessage("The Business Id must be valid.");

            RuleFor(a => a.Password)
                .NotEmpty().WithMessage("The password must be valid.")
                .MinimumLength(6).WithMessage("The password must be at least 6 characters.");

            RuleFor(a => a.AgencyNumber)
                .NotNull().WithMessage("The agency number must be configured.");

            RuleFor(a => a.PIN)
                .NotNull().WithMessage("The PIN must be configured.");
        }

    }
}