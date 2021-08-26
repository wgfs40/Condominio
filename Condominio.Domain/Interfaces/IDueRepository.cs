using Condominio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Domain.Interfaces
{
    public interface IDueRepository : IDisposable
    {
        Task<Due> GetById(int DueId);
        Task<IEnumerable<Due>> GetAll();
        Task<IEnumerable<Due>> GetAllByCustomerId(int CustomerId);
        //Task<IEnumerable<Customer>> Search(Expression<Func<Customer, bool>> predicate);
        void Add(Due residencial);
        void Update(Due residencial);
        void Remove(Due residencial);
        int SaveChanges();
    }
}
