using Condominio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Domain.Interfaces
{
    public interface ICustomerRepository : IDisposable
    {
        Task<Customer> GetById(int CustomerId);
        Task<IEnumerable<Customer>> GetAll();
        //Task<IEnumerable<Customer>> Search(Expression<Func<Customer, bool>> predicate);
        void Add(Customer  customer);
        void Update(Customer customer);
        void Remove(Customer customer);

        int SaveChanges();


    }
}
