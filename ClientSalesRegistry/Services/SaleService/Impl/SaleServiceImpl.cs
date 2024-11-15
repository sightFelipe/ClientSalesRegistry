using ClientSalesRegistry.Data;
using ClientSalesRegistry.DTOs;
using ClientSalesRegistry.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSalesRegistry.Services.SaleService.Impl
{
    public class SaleServiceImpl : ISaleService
    {
        private readonly AppDbContext _context;

        public SaleServiceImpl(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<SaleDto> AddSaleAsync(SaleDto saleDto)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Document == saleDto.Document);

            if (customer == null)
            {
                throw new Exception($"El cliente con documento {saleDto.Document} no se encontró.");
            }

            var sale = new Sale
            {
                SaleDate = DateTime.UtcNow,
                CustomerId = customer.Id,
                SaleItems = new List<SaleItem>()
            };

            foreach (var item in saleDto.SaleItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                {
                    throw new Exception($"El producto con ID {item.ProductId} no se encontró.");
                }

                var saleItem = new SaleItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    TotalPriceWithoutTax = product.PriceWithoutTax * item.Quantity,
                    TotalPriceWithTax = product.PriceWithTax * item.Quantity
                };

                sale.SaleItems.Add(saleItem);
            }

            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();

            saleDto.Id = sale.Id;
            return saleDto;
        }

        public async Task<List<SaleDto>> GetSalesByCustomerDocumentAsync(string document)
        {
            var sales = await _context.Sales
                .Include(s => s.SaleItems)
                .ThenInclude(si => si.Product)
                .Where(s => s.Customer.Document == document)
                .ToListAsync();

            var saleDtos = sales.Select(s => new SaleDto
            {
                Id = s.Id,
                SaleDate = s.SaleDate,
                CustomerId = s.CustomerId,
                SaleItems = s.SaleItems.Select(si => new SaleItemDto
                {
                    ProductId = si.ProductId,
                    Quantity = si.Quantity,
                    TotalPriceWithoutTax = si.TotalPriceWithoutTax,
                    TotalPriceWithTax = si.TotalPriceWithTax
                }).ToList()
            }).ToList();

            return saleDtos;
        }
    }
}