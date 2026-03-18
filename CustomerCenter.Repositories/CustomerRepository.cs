using CustomerCenter.Data;
using CustomerCenter.Domain.Data;
using CustomerCenter.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerCenter.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _context;

    public CustomerRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
        => await _context.Customers.AsNoTracking().ToListAsync();

    public async Task<Customer?> GetByIdAsync(int id)
        => await _context.Customers.FindAsync(id);

    public async Task<Customer> AddAsync(Customer customer)
    {
        customer.CreatedAt = DateTime.UtcNow;
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task UpdateAsync(Customer customer)
    {
        customer.UpdatedAt = DateTime.UtcNow;
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();        
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Customers.FindAsync(id);
        if (entity is null) return;

        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
