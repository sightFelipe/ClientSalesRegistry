using ClientSalesRegistry.Data;
using ClientSalesRegistry.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientSalesRegistry.Repositories.ProductRepository
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private readonly AppDbContext _context; 

        public ProductRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id); 
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); 
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product); 
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product); 
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product); 
                await _context.SaveChangesAsync(); 
            }
        }
    }
}
