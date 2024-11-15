using ClientSalesRegistry.DTOs;
using ClientSalesRegistry.Factories;
using ClientSalesRegistry.Models;
using ClientSalesRegistry.Repositories.CustomerRepository;

namespace ClientSalesRegistry.Services.customerService.impl
{
    public class CustomerServiceImpl : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServiceImpl(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto)
        {
            var customer = CustomerFactory.CreateCustomer(customerDto);
            await _customerRepository.AddAsync(customer);

            return new CustomerDto
            {
                Document = customer.Document,
                Name = customer.Name,
                Email = customer.Email,
                EmailType = customer.EmailType
            };
        }

        public async Task<CustomerDto> GetCustomerByDocumentAsync(string document)
        {
            var customer = await _customerRepository.GetByDocumentAsync(document);
            if (customer == null) return null;

            return new CustomerDto
            {
                Document = customer.Document,
                Name = customer.Name,
                Email = customer.Email,
                EmailType = customer.EmailType
            };
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            var customerDtos = new List<CustomerDto>();

            foreach (var customer in customers)
            {
                customerDtos.Add(new CustomerDto
                {
                    Document = customer.Document,
                    Name = customer.Name,
                    Email = customer.Email,
                    EmailType = customer.EmailType
                });
            }

            return customerDtos;
        }

        public async Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto, string document)
        {
          
            var existingCustomer = await _customerRepository.GetByDocumentAsync(document);
            if (existingCustomer == null) return null;

            
            if (existingCustomer.Document != customerDto.Document)
            {
               
                var documentExists = await _customerRepository.GetByDocumentAsync(customerDto.Document);
                if (documentExists != null)
                {
                    throw new InvalidOperationException("El nuevo documento ya está en uso por otro cliente.");
                }
            }

            
            existingCustomer.Name = customerDto.Name;
            existingCustomer.Email = customerDto.Email;
            existingCustomer.EmailType = customerDto.EmailType;

            
            existingCustomer.Document = customerDto.Document;

          
            var updatedCustomer = await _customerRepository.UpdateAsync(existingCustomer);

            return new CustomerDto
            {
                Document = updatedCustomer.Document,
                Name = updatedCustomer.Name,
                Email = updatedCustomer.Email,
                EmailType = updatedCustomer.EmailType
            };
        }

        public async Task DeleteCustomerAsync(string document)
        {
            
            if (string.IsNullOrWhiteSpace(document))
            {
                throw new ArgumentException("El documento del cliente es obligatorio.");
            }

            
            var customer = await _customerRepository.GetByDocumentAsync(document);
            if (customer == null)
            {
                throw new KeyNotFoundException($"No se encontró un cliente con el documento: {document}");
            }

           
            await _customerRepository.DeleteAsync(document);
        }
    }
}