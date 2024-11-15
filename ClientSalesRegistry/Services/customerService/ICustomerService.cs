using ClientSalesRegistry.DTOs;

namespace ClientSalesRegistry.Services.customerService
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto);
        Task<CustomerDto> GetCustomerByDocumentAsync(string document);
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto, string document);
        Task DeleteCustomerAsync(string document);
    }
}
