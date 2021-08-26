using System.Collections.Generic;

namespace Condominio.Domain.Models
{
    public class Residencial
    {
        public int ResidentialId { get; }
        public int CondominiumId { get; }
        public string ResidentialName { get; }

        //Relations
        public Condominium  Condominium { get; }
        public List<Customer> Customer { get; }
        public Residencial(int residentialId, int condominiumId, string residentialName)
        {
            ResidentialId = residentialId;
            CondominiumId = condominiumId;
            ResidentialName = residentialName;
        }
    }
}
