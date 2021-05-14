using Data.Entities;
using Libraries.Abstraction.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IAgencyRepository : IRepository<Agency>
    {
        Agency GetByBusinessId(string businessId);
    }
}