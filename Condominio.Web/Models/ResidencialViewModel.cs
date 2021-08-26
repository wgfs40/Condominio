using System.ComponentModel.DataAnnotations;

namespace Condominio.Web.Models
{
    public class ResidencialViewModel
    {
        public int ResidentialId { get; set; }
        [Required(ErrorMessage = "debe seleccionar el condominio")]
        public int CondominiumId { get; set; }
        [Required(ErrorMessage = "el nombre del residencial es requerido")]
        public string ResidentialName { get; set; }

        
        public CondominiumViewModel Condominium { get; set; }
    }
}
