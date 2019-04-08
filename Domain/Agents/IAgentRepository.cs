using StarkIndustries.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkIndustries.Domain.Agents
{
    public interface IAgentRepository
{
        Task<IEnumerable<Agent>> GetAgentsAsync();
        Task<Agent> GetAgentAsync(int id);
        Task<Agent> CreateAgentAsync(Agent agent);
        Task<Agent> UpdateAgentAsync(int id, Agent agent);
}
}
