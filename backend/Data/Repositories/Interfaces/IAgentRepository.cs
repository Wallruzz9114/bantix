using Data.Entities;
using Data.ViewModels;
using Libraries.Abstraction.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IAgentRepository : IRepository<Agent>
    {
        AgentViewModel GetByBusinessId(string businessId);
        AgentViewModel CreateAgent(string fullName, string displayName, string businessId, string password, string agentNumber, string pin);
    }
}