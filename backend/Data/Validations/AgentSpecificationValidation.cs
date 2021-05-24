using System;
using Data.Entities;
using Data.Repositories.Interfaces;
using Data.Specifications;
using FluentValidation;
using Libraries.Abstraction.Extensions;
using Libraries.Abstraction.Validations;

namespace Data.Validations
{
    public class AgentSpecificationValidation : EntityValidator<Agent>
    {
        private readonly IAgentRepository _agentRepository;

        public AgentSpecificationValidation(Agent agent, IAgentRepository agentRepository) : base(agent)
        {
            _agentRepository = agentRepository ?? throw new ArgumentNullException(nameof(agentRepository));

            RuleFor(a => a)
                .IsValid(new UniqueAgentSpecification(agent, _agentRepository))
                .WithMessage("This agent is alrady in the database.");
        }
    }
}