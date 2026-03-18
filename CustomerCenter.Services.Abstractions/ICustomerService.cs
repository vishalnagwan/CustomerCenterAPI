using CustomerCenter.Domain.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerCenter.Services.Abstractions;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer> CreateAsync(Customer customer);
    Task UpdateAsync(int id, Customer customer);
    Task DeleteAsync(int id);
}
