using System;
using System.Linq;
using AutoMapper;
using Data.Entities;
using Data.Repositories.Interfaces;
using Data.ViewModels;
using Libraries.Helpers;

namespace Data.Repositories.Implementations
{
    public class AgentRepository : Repository<Agent>, IAgentRepository, IDisposable
    {
        private readonly IMapper _mapper;

        public AgentRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public AgentViewModel GetByBusinessId(string businessId)
        {
            var agent = _dbContext.Agents.SingleOrDefault(a => a.BusinessId == businessId);
            return _mapper.Map<AgentViewModel>(agent);
        }

        public AgentViewModel CreateAgent(string fullName, string displayName, string businessId, string password, string agentNumber, string pin)
        {
            if (!_dbContext.Agents.Any(a => a.DisplayName == displayName))
            {
                var newAgent = new Agent
                {
                    FullName = fullName,
                    DisplayName = displayName,
                    BusinessId = businessId,
                    Password = Cryptography.EncryptWithMD5(password),
                    AgentNumber = agentNumber,
                    PIN = pin
                };

                return _mapper.Map<AgentViewModel>(newAgent);
            }

            throw new Exception("An agent with this name already exists");
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