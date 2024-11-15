using System.ComponentModel.DataAnnotations;

namespace ClientSalesRegistry.DTOs
{
    public class CustomerDto
    {
        [Required(ErrorMessage = "El documento es obligatorio.")]
        [StringLength(50, ErrorMessage = "El documento no puede exceder los 50 caracteres.")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del cliente no puede exceder los 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede exceder los 255 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El tipo de correo es obligatorio.")]
        [RegularExpression("^[PW]$", ErrorMessage = "El tipo de correo debe ser 'P' (personal) o 'W' (trabajo).")]
        public char EmailType { get; set; }
    }
}