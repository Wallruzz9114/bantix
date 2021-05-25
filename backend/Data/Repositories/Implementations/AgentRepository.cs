using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Data.Helpers;
using Data.Repositories.Interfaces;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations
{
    public class AgentRepository : Repository<Agent>, IAgentRepository, IDisposable
    {
        private readonly IMapper _mapper;

        public AgentRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<AgentViewModel> GetByBusinessId(string businessId)
        {
            var agent = await _dbContext.Agents.SingleOrDefaultAsync(a => a.BusinessId == businessId);
            return _mapper.Map<AgentViewModel>(agent);
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

        public async Task<AgentViewModel> CreateAgentAsync(string fullName, string displayName, string businessId, string password, string agentNumber, string pin)
        {
            var isUnique = _dbContext.Agents
                .Where(x => x.DisplayName == displayName || x.AgentNumber == agentNumber)
                .Any();

            if (!isUnique)
            {
                throw new Exception("The display name or agent number are already in use");
            }

            var newAgent = new Agent
            {
                FullName = fullName,
                DisplayName = displayName,
                BusinessId = businessId,
                Password = Cryptography.HashPassword(password),
                AgentNumber = agentNumber,
                PIN = pin
            };

            _dbContext.Agents.Add(newAgent);
            var agentCreated = await _dbContext.SaveChangesAsync() > 0;

            throw new NotImplementedException();
        }
    }
}