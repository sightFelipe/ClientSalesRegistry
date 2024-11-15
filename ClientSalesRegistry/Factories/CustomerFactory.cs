using ClientSalesRegistry.DTOs;
using ClientSalesRegistry.Models;
using ClientSalesRegistry.Repositories.CustomerRepository; 
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientSalesRegistry.Factories
{
    public static class CustomerFactory
    {
        public static async Task<Customer> CreateCustomerAsync(CustomerDto customerDto, ICustomerRepository customerRepository)
        {
            if (string.IsNullOrWhiteSpace(customerDto.Document))
            {
                throw new ArgumentException("El documento es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(customerDto.Name))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(customerDto.Email))
            {
                throw new ArgumentException("El correo electrónico es obligatorio.");
            }

            if (customerDto.EmailType != 'P' && customerDto.EmailType != 'W')
            {
                throw new ArgumentException("El tipo de correo debe ser 'P' (personal) o 'W' (trabajo).");
            }

            if (customerDto.EmailType == default(char))
            {
                throw new ArgumentException("El tipo de correo no puede estar vacío.");
            }

            if (!IsValidEmail(customerDto.Email))
            {
                throw new ArgumentException("El formato del correo electrónico no es válido.");
            }

            if (await customerRepository.IsEmailInUse(customerDto.Email))
            {
                throw new ArgumentException("El correo electrónico ya está en uso por otro cliente.");
            }

            return new Customer
            {
                Document = customerDto.Document,
                Name = customerDto.Name,
                Email = customerDto.Email,
                EmailType = customerDto.EmailType
            };
        }

        private static bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }
    }
}