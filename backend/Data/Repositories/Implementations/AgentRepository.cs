using System;
using System.Linq;
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class AgentRepository : Repository<Agent>, IAgentRepository, IDisposable
    {
        public AgentRepository(AppDbContext dbContext) : base(dbContext) { }

        public Agent GetByBusinessId(string businessId)
        {
            return _dbContext.Agents.SingleOrDefault(a => a.BusinessId == businessId);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing) _dbContext.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}