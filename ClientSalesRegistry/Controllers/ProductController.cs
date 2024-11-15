using ClientSalesRegistry.Services.ProductService;
using ClientSalesRegistry.DTOs; 
using Microsoft.AspNetCore.Mvc;

namespace ClientSalesRegistry.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                return Ok(product);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Producto no encontrado para ID: {id}");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                return Ok(products);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Add([FromBody] ProductDto productDto) 
        {
            if (productDto == null)
            {
                return BadRequest("El producto no puede ser nulo.");
            }

            try
            {
                await _productService.AddAsync(productDto); 
                return CreatedAtAction(nameof(GetById), new { id = productDto.ProductId }, productDto); 
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("El producto es nulo.");
            }

            
            productDto.ProductId = id;

            try
            {
                await _productService.UpdateAsync(productDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Producto no encontrado para ID: {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Producto no encontrado para ID: {id}");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}