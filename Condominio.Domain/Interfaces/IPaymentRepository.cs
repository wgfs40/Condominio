using Condominio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Domain.Interfaces
{
    public interface IPaymentRepository : IDisposable
    {
        Task<Payment> GetById(int PaymentId);
        Task<IEnumerable<Payment>> GetAll();
        Task<IEnumerable<Payment>> GetAllByCustomerId(int CustomerId);
        //Task<IEnumerable<Customer>> Search(Expression<Func<Customer, bool>> predicate);
        void Add(Payment payment);
        void Update(Payment payment);
        void Remove(Payment payment);
        int SaveChanges();
    }
}
