using System.Collections.Generic;

namespace Condominio.Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public int ResidentialId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        //Relations
        public Residencial Residencial { get;}
        public List<Due> Dues { get; }
        public List<Payment>  Payments { get; }
        public Customer(int customerId, int residentialId, string firstName, string lastName, string phone, string email)
        {
            CustomerId = customerId;
            ResidentialId = residentialId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }

    }
}
