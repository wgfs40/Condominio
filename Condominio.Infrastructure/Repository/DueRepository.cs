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
    public class DueRepository : IDueRepository
    {
        protected readonly CondominioContext Db;
        protected readonly DbSet<Due> DbSet;

        public DueRepository(CondominioContext condominioContext)
        {
            Db = condominioContext;
            DbSet = Db.Set<Due>();
        }
        public void Add(Due due)
        {
            DbSet.Add(due);
        }

        public async Task<IEnumerable<Due>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<Due>> GetAllByCustomerId(int CustomerId)
        {
            var list = await  DbSet.Where(d => d.CustomerId == CustomerId).ToListAsync();
            return list;
        }

        public async Task<Due> GetById(int DueId)
        {
            return await DbSet.FindAsync(DueId);
        }

        public void Remove(Due due)
        {
            DbSet.Remove(due);
        }

        public void Update(Due due)
        {
            DbSet.Update(due);
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
