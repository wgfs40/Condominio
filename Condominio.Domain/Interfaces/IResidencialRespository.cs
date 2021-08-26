using Condominio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Domain.Interfaces
{
    public interface  IResidencialRespository : IDisposable
    {
        Task<Residencial> GetById(int ResidentialId);
        Task<IEnumerable<Residencial>> GetAll();
        //Task<IEnumerable<Customer>> Search(Expression<Func<Customer, bool>> predicate);
        void Add(Residencial residencial);
        void Update(Residencial residencial);
        void Remove(Residencial residencial);

        int SaveChanges();
    }
}
