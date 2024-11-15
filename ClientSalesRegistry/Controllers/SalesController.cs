using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ClientSalesRegistry.DTOs;
using ClientSalesRegistry.Services;
using ClientSalesRegistry.Services.SaleService;

namespace ClientSalesRegistry.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterSale([FromBody] SaleDto saleDto)
        {
            if (saleDto == null)
            {
                return BadRequest("Los datos de la venta son obligatorios.");
            }

            
            var result = await _saleService.AddSaleAsync(saleDto);
            return Ok(result);
        }

        [HttpGet]
        [Route("customer/{document}")] 
        public async Task<IActionResult> GetSalesByCustomer(string document)
        {
            var sales = await _saleService.GetSalesByCustomerDocumentAsync(document); 
            if (sales == null || sales.Count == 0)
            {
                return NotFound($"No se encontraron ventas para el cliente con documento {document}.");
            }

            return Ok(sales);
        }
    }
}