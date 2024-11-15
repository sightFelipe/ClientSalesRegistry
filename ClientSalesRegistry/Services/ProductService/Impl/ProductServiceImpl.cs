using ClientSalesRegistry.Models;
using ClientSalesRegistry.Repositories.ProductRepository;
using ClientSalesRegistry.DTOs; 

namespace ClientSalesRegistry.Services.ProductService.Impl
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<IProductService> _logger;

        public ProductServiceImpl(IProductRepository productRepository, ILogger<IProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("GetByIdAsync: ID no válido: {id}", id);
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));
            }

            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    _logger.LogWarning("GetByIdAsync: Producto no encontrado para ID: {id}", id);
                    throw new KeyNotFoundException($"Producto no encontrado para ID: {id}");
                }

               
                return new ProductDto
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    PriceWithoutTax = product.PriceWithoutTax
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el producto por ID: {id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();

                
                return products.Select(product => new ProductDto
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    PriceWithoutTax = product.PriceWithoutTax
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los productos");
                throw;
            }
        }

        public async Task AddAsync(ProductDto productDto)
        {
            if (productDto == null)
            {
                _logger.LogWarning("AddAsync: Producto es nulo");
                throw new ArgumentNullException(nameof(productDto), "El producto no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(productDto.Name))
            {
                _logger.LogWarning("AddAsync: El nombre del producto no puede estar vacío.");
                throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(productDto.Name));
            }

            try
            {
               
                var product = new Product
                {
                    Name = productDto.Name,
                    PriceWithoutTax = productDto.PriceWithoutTax,
                    PriceWithTax = productDto.PriceWithoutTax * 1.19m 
                };

                await _productRepository.AddAsync(product); 
                _logger.LogInformation("Producto agregado: {productName}", product.Name);

                
                productDto.ProductId = product.Id; 
                productDto.PriceWithTax = product.PriceWithTax; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar el producto: {productName}", productDto.Name);
                throw;
            }
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            if (productDto == null)
            {
                _logger.LogWarning("UpdateAsync: Producto es nulo");
                throw new ArgumentNullException(nameof(productDto), "El producto no puede ser nulo.");
            }

          
            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(productDto.ProductId);
                if (existingProduct == null)
                {
                    _logger.LogWarning("UpdateAsync: Producto no encontrado para ID: {productId}", productDto.ProductId);
                    throw new KeyNotFoundException($"Producto no encontrado para ID: {productDto.ProductId}");
                }

                
                existingProduct.Name = productDto.Name;
                existingProduct.PriceWithoutTax = productDto.PriceWithoutTax;

                await _productRepository.UpdateAsync(existingProduct);
                _logger.LogInformation("Producto actualizado: {productName}", existingProduct.Name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el producto: {productId}", productDto.ProductId);
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("DeleteAsync: ID no válido: {id}", id);
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));
            }

            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(id);
                if (existingProduct == null)
                {
                    _logger.LogWarning("DeleteAsync: Producto no encontrado para ID: {id}", id);
                    throw new KeyNotFoundException($"Producto no encontrado para ID: {id}");
                }

                await _productRepository.DeleteAsync(id);
                _logger.LogInformation("Producto eliminado: {productId}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el producto con ID: {id}", id);
                throw;
            }
        }
    }
}