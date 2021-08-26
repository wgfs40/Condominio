using System.ComponentModel.DataAnnotations;

namespace Condominio.Web.Models
{
    public class CondominiumViewModel
    {
        public int CondominiumId { get; set; }
        [Required(ErrorMessage = "el nombre del condominio es requerido")]
        [MinLength(3,ErrorMessage = "el nombre del condominio debe tener minimo 3  caracteres o mas")]
        public string BusinessName { get; set; }
        [Required(ErrorMessage = "el telefono es requerido")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "numero de telefon es incorrecto. ejemplo 8097897444")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "la direccion es requerida")]
        [MinLength(3, ErrorMessage = "la direccion del condominio debe tener minimo de 3 caracteres o mas")]
        public string Address { get; set; }
        [Required(ErrorMessage = "el correo electronico es requerido")]
        [EmailAddress(ErrorMessage = "el correo electronico es invalido")]
        public string Email { get; set; }
    }
}
