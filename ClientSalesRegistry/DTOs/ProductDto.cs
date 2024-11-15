using System.ComponentModel.DataAnnotations;

namespace ClientSalesRegistry.DTOs
{
    

    public class ProductDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio sin impuestos debe ser mayor o igual a cero.")]
        public decimal PriceWithoutTax { get; set; }

        public decimal PriceWithTax { get; set; }  
    }
}
