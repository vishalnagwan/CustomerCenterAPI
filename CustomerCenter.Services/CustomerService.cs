using CustomerCenter.Domain.Data;
using CustomerCenter.Repositories.Abstractions;
using CustomerCenter.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerCenter.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repo;

    public CustomerService(ICustomerRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Customer>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Customer?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public Task<Customer> CreateAsync(Customer customer)
        => _repo.AddAsync(customer);

    public async Task UpdateAsync(Customer customer)
    {
        var existing = await _repo.GetByIdAsync(customer.Id);
        if (existing is null) return;

        existing.FirstName = customer.FirstName;
        existing.LastName = customer.LastName;
        existing.Email = customer.Email;
        existing.Phone = customer.Phone;
        existing.DateOfBirth = customer.DateOfBirth;
        existing.AddressLine1 = customer.AddressLine1;
        existing.AddressLine2 = customer.AddressLine2;
        existing.City = customer.City;
        existing.State = customer.State;
        existing.PostalCode = customer.PostalCode;
        existing.Country = customer.Country;
        existing.IsActive = customer.IsActive;
        existing.LoyaltyNumber = customer.LoyaltyNumber;
        existing.Notes = customer.Notes;

        await _repo.UpdateAsync(existing);
    }

    public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
}
