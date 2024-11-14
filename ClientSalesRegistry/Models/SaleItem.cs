using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientSalesRegistry.Models
{
    public class SaleItem
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [ForeignKey("Sale")] 
        public int SaleId { get; set; }

        public Sale Sale { get; set; } 

        [ForeignKey("Product")] 
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser un valor positivo.")]
        public int Quantity { get; set; }
    }
}