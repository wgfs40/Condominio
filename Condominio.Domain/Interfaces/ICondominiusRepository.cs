using Condominio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Domain.Interfaces
{
    public interface ICondominiusRepository : IDisposable
    {
        Task<Condominium> GetById(int CondominiunId);
        Task<IEnumerable<Condominium>> GetAll();        
        //Task<IEnumerable<Customer>> Search(Expression<Func<Customer, bool>> predicate);
        void Add(Condominium condominium);
        void Update(Condominium condominium);
        void Remove(Condominium condominium);
        int SaveChanges();
    }
}
