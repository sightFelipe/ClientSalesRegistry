using ClientSalesRegistry.Models;

namespace ClientSalesRegistry.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> GetByDocumentAsync(string document);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> UpdateAsync(Customer customer);
        Task DeleteAsync(string document);
    }
}
