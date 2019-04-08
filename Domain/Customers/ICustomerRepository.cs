using StarkIndustries.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkIndustries.Domain.Customers
{
    public interface ICustomerRepository
{
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(string id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(string id, Customer customer);
        Task<Customer> DeleteCustomerAsync(string id);
        Task<Agent> GetCustomersByAgentAsync(int id);
}
}
