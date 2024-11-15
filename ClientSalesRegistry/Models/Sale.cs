using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientSalesRegistry.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de venta es obligatoria.")]
        public DateTime SaleDate { get; set; }

        [ForeignKey("Customer")]
        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required(ErrorMessage = "La lista de artículos de venta no puede estar vacía.")]
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}