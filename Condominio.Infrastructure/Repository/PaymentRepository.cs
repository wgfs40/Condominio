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
    public class PaymentRepository : IPaymentRepository
    {
        protected readonly CondominioContext Db;
        protected readonly DbSet<Payment> DbSet;

        public PaymentRepository(CondominioContext condominioContext)
        {
            Db = condominioContext;
            DbSet = Db.Set<Payment>();
        }

        public void Add(Payment payment)
        {
            DbSet.Add(payment);
        }
        public async Task<IEnumerable<Payment>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetAllByCustomerId(int CustomerId)
        {
            var list = await DbSet.Where(d => d.CustomerId == CustomerId).ToListAsync();
            return list;
        }

        public async Task<Payment> GetById(int PaymentId)
        {
            return await DbSet.FindAsync(PaymentId);
        }

        public void Remove(Payment payment)
        {
            DbSet.Remove(payment);
        }

        public void Update(Payment payment)
        {
            DbSet.Update(payment);
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
