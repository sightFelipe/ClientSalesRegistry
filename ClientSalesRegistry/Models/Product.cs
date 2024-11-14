using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientSalesRegistry.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del producto no puede exceder los 100 caracteres.")]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio sin impuestos debe ser un valor positivo.")]
        public decimal PriceWithoutTax { get; set; }

        public decimal PriceWithTax => PriceWithoutTax * 1.19m;

        public override string ToString()
        {
            return $"{Name} - Precio sin impuestos: {PriceWithoutTax:C} - Precio con impuestos: {PriceWithTax:C}";
        }
    }
}