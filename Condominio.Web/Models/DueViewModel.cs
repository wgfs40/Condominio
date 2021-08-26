using System.ComponentModel.DataAnnotations;

namespace Condominio.Web.Models
{
    public class DueViewModel
    {
        public int DueId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int PaymentDay { get; set; }
        [Required]
        public decimal PercentCharges { get; set; }
    }
}
