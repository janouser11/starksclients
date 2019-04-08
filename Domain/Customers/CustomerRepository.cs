using Microsoft.EntityFrameworkCore;
using StarkIndustries.Data;
using StarkIndustries.Data.DbModels;
using StarkIndustries.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApiContext _context;

    public CustomerRepository(ApiContext context)
    {
        _context = context;
    }
    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> DeleteCustomerAsync(string id)
    {
        var itemToRemove = await _context.Customers.SingleOrDefaultAsync(x => x.Guid == id);

        if (itemToRemove != null)
        {
            _context.Customers.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return itemToRemove;
        }
        return null;
    }

    public async Task<Customer> GetCustomerAsync(string id)
    {
        var customer = await _context.Customers.FindAsync(id);
        return customer;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var customers = await _context.Customers.ToListAsync();
        return customers;
    }

    public async Task<Customer> UpdateCustomerAsync(string id, Customer customer)
    {
        if (id != customer.Guid)
        {
            throw new Exception("Id's must match when updating agent");
        }

        var customerToUpdate = await _context.Customers.SingleOrDefaultAsync(x => x.Guid == id);
        if (customerToUpdate != null)
        {
            _context.Entry(customerToUpdate).CurrentValues.SetValues(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        return null;
    }

    public async Task<Agent> GetCustomersByAgentAsync(int id)
    {
        var agent = await _context.Agents.Include(x => x.Customers).FirstOrDefaultAsync(x => x._id == id);
        return agent;
    }
}
