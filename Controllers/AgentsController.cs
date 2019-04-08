using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarkIndustries.Data;
using StarkIndustries.Data.DbModels;
using StarkIndustries.Domain.Agents;

namespace Stark_Industries.Controllers
{
    [Route("api/agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {

        private readonly IAgentRepository _agentRepository;

        public AgentsController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        // GET: api/Agents
        /// <summary>
        /// Return all agents
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAgentsAsync()
        {
            var agents =  await _agentRepository.GetAgentsAsync();

            if (agents == null)
            {
                return NotFound();
            }
            return Ok(agents);
        }


        // GET: api/Agents/5
        /// <summary>
        /// Return a specific agent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgentAsync(int id)
        {
            var agent = await _agentRepository.GetAgentAsync(id);
            if (agent == null)
            {
                return NotFound();
            } 
            return Ok(agent);

        }


        // POST: api/Agents
        /// <summary>
        /// Create a new agent
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task<IActionResult> CreateAgentAsync([FromBody] Agent agent)
        {
            var createdAgent = await _agentRepository.CreateAgentAsync(agent);
            return Ok(createdAgent);
        }


        // PUT: api/Agents/5
        /// <summary>
        /// Update an agent
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgentAsync(int id, [FromBody] Agent agent)
        {

            var updatedAgent = await _agentRepository.UpdateAgentAsync(id, agent);
            return Ok(updatedAgent);

        }

    }
}
