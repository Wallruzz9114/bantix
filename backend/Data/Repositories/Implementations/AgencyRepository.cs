using System;
using System.Linq;
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class AgencyRepository : Repository<Agency>, IAgencyRepository, IDisposable
    {
        public AgencyRepository(AppDbContext dbContext) : base(dbContext) { }

        public Agency GetByBusinessId(string businessId)
        {
            return _dbContext.Agencies.SingleOrDefault(a => a.BusinessId == businessId);
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