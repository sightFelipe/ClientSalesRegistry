using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClientSalesRegistry.Models;
using ClientSalesRegistry.Data;

namespace ClientSalesRegistry.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> GetByDocumentAsync(string document)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Document == document);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(string document)
        {
            var customer = await GetByDocumentAsync(document);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
         public async Task<bool> IsEmailInUse(string email)
        {
            return await _context.Customers.AnyAsync(c => c.Email.ToLower() == email.ToLower());
        }
    }
}