using Data.Entities;
using Libraries.Abstraction.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Agent GetByBusinessId(string businessId);
    }
}