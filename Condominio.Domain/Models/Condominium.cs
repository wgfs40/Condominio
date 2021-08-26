using System.Collections.Generic;

namespace Condominio.Domain.Models
{
    public class Condominium
    {
        public int CondominiumId { get; private set; }
        public string BusinessName { get; private set; }
        public string Phone { get; private set; }

        public string Address { get; private set; }

        public string Email { get; private set; }

        //Relations
        public List<Residencial> Residencials { get; private set; }


       
        public Condominium(int condominiumId, string businessName, string phone, string address, string email)
        {
            CondominiumId = condominiumId;
            BusinessName = businessName;
            Phone = phone;
            Address = address;
            Email = email;
        }
    }
}
