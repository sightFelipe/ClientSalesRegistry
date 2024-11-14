using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientSalesRegistry.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del cliente no puede exceder los 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede exceder los 255 caracteres.")]
        public string Email { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale>(); 

        public override string ToString()
        {
            return $"{Name} - {Email}";
        }
    }
}