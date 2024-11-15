using System.ComponentModel.DataAnnotations;

namespace ClientSalesRegistry.DTOs
{
    public class SaleItemDto
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser un valor positivo.")]
        public int Quantity { get; set; }

        public decimal TotalPriceWithoutTax { get; set; }
        public decimal TotalPriceWithTax { get; set; }
    }
}