using Microsoft.EntityFrameworkCore;
using StarkIndustries.Data;
using StarkIndustries.Data.DbModels;
using StarkIndustries.Domain.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class AgentRepository : IAgentRepository
{
    private readonly ApiContext _context;

    public AgentRepository(ApiContext context)
    {
        _context = context;
    }

    public async Task<Agent> CreateAgentAsync(Agent agent)
    {
        await _context.Agents.AddAsync(agent);
        await _context.SaveChangesAsync();
        return agent;
    }

    public async Task<Agent> GetAgentAsync(int id)
    {
        var agent = await _context.Agents.FindAsync(id);
        return agent;
    }

    public async Task<IEnumerable<Agent>> GetAgentsAsync()
    {
        var agents = await _context.Agents.ToListAsync();
        return agents;
    }

    public async Task<Agent> UpdateAgentAsync(int id, Agent agent)
    {
        if (id != agent._id)
        {
            throw new Exception("Id's must match when updating agent");
        }

        var agentToUpdate = await _context.Agents.SingleOrDefaultAsync(x => x._id == id);
        if (agentToUpdate != null)
        {
             _context.Entry(agentToUpdate).CurrentValues.SetValues(agent);
           await  _context.SaveChangesAsync();
            return agent;
        }
        return null;
    }
}
