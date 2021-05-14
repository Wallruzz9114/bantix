using System;
using System.Linq;
using Data.Entities;
using Data.Repositories.Interfaces;
using Libraries.Abstraction.Validations;

namespace Data.Specifications
{
    public class UniqueAgencySpecification : EntitySpecification<Agency>
    {
        private readonly IAgencyRepository _agencyRepository;

        public UniqueAgencySpecification(Agency agency, IAgencyRepository agencyRepository) : base(agency)
        {
            _agencyRepository = agencyRepository ?? throw new ArgumentNullException(nameof(agencyRepository));
        }

        public override bool IsValid() => !_agencyRepository.GetAll().Any();
    }
}