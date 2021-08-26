using System.ComponentModel.DataAnnotations;

namespace Condominio.Applications.ViewModels
{
    public class ResidencialViewModel
    {
        public int ResidentialId { get; set; }
        [Required]
        public int CondominiumId { get; set; }
        [Required]
        public string ResidentialName { get; set; }

        public CondominiumViewModel Condominium { get; set; }
    }
}
