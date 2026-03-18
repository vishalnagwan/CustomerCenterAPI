using CustomerCenter.Domain.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerCenter.Repositories.Abstractions;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer> AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}
