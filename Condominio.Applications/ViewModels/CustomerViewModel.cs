using System.ComponentModel.DataAnnotations;

namespace Condominio.Applications.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required]
        public int ResidentialId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        public ResidencialViewModel Residencial { get; set; }
    }
}
