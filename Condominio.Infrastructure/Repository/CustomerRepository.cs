using Condominio.Domain.Interfaces;
using Condominio.Domain.Models;
using Condominio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominio.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly CondominioContext Db;
        protected readonly DbSet<Customer> DbSet;
        public CustomerRepository(CondominioContext condominioContext)
        {
            Db = condominioContext;
            DbSet = Db.Set<Customer>();
        }
        public void Add(Customer customer)
        {
            DbSet.Add(customer);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var list = await DbSet.Include(c => c.Residencial).ToArrayAsync();
            return list;
        }

        public async Task<Customer> GetById(int CustomerId)
        {            
            return await DbSet.FindAsync(CustomerId);
        }

        public void Remove(Customer customer)
        {
            DbSet.Remove(customer);
        }

        public void Update(Customer customer)
        {
            DbSet.Update(customer);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
