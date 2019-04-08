using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarkIndustries.Data;
using StarkIndustries.Domain.Customers;

namespace Stark_Industries.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        // GET: api/Customers
        /// <summary>
        /// Return all customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetCustomersAsync();
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // GET: api/Customers/5
        /// <summary>
        /// Return a customers details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(string id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/Customers
        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] Customer customer)
        {
            return Ok(await _customerRepository.CreateCustomerAsync(customer));
        }

        // PUT: api/Customers/5
        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(string id, [FromBody] Customer customer)
        {
            return Ok(await _customerRepository.UpdateCustomerAsync(id, customer));
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Deletes an existing customer
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _customerRepository.DeleteCustomerAsync(id));
        }

        // GET: api/Customers/agent/5
        /// <summary>
        /// Return all customers associated with a agent's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("agent/{id}")]
        public async Task<IActionResult> GetCustomersByAgentAsync(int id)
        {
            var customers = await _customerRepository.GetCustomersByAgentAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }
    }
}
