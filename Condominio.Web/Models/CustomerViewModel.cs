using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Condominio.Web.Models
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
        public List<DueViewModel> Dues { get; set; }
        public List<PaymentViewModel> Payments { get; set; }
    }
}
