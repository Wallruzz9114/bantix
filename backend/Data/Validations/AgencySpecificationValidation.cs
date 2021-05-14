using System;
using Data.Entities;
using Data.Repositories.Interfaces;
using Data.Specifications;
using FluentValidation;
using Libraries.Abstraction.Extensions;
using Libraries.Abstraction.Validations;

namespace Data.Validations
{
    public class AgencySpecificationValidation : EntityValidator<Agency>
    {
        private readonly IAgencyRepository _agencyRepository;

        public AgencySpecificationValidation(Agency agency, IAgencyRepository agencyRepository) : base(agency)
        {
            _agencyRepository = agencyRepository ?? throw new ArgumentNullException(nameof(agencyRepository));

            RuleFor(a => a)
                .IsValid(new UniqueAgencySpecification(agency, _agencyRepository))
                .WithMessage("This agency is alrady in the database.");
        }
    }
}