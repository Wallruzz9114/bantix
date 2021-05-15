using System;
using System.Linq;
using Data.Entities;
using Data.Repositories.Interfaces;
using Libraries.Abstraction.Validations;

namespace Data.Specifications
{
    public class UniqueAgentSpecification : EntitySpecification<Agent>
    {
        private readonly IAgentRepository _agentRepository;

        public UniqueAgentSpecification(Agent agent, IAgentRepository agentRepository) : base(agent)
        {
            _agentRepository = agentRepository ?? throw new ArgumentNullException(nameof(agentRepository));
        }

        public override bool IsValid() => !_agentRepository.GetAll().Any();
    }
}