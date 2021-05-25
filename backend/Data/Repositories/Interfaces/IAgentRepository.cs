using System.Threading.Tasks;
using Data.Entities;
using Data.ViewModels;
using Libraries.Abstraction.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Task<AgentViewModel> GetByBusinessId(string businessId);
        Task<AgentViewModel> CreateAgentAsync(string fullName, string displayName, string businessId, string password, string agentNumber, string pin);
    }
}