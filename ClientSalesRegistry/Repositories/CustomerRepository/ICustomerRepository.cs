using System.Collections.Generic;
using System.Threading.Tasks;
using ClientSalesRegistry.Models;

public interface ICustomerRepository
{
    Task<Customer> AddAsync(Customer customer);
    Task<Customer> GetByDocumentAsync(string document); 
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> UpdateAsync(Customer customer);
    Task DeleteAsync(string document); 
}