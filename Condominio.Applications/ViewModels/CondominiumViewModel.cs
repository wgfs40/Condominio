using System.ComponentModel.DataAnnotations;

namespace Condominio.Applications.ViewModels
{
    public class CondominiumViewModel
    {
        public int CondominiumId { get; set; }
        [Required]
        public string BusinessName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
