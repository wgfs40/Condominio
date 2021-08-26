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
    public class CondominiusRepository : ICondominiusRepository
    {
        protected readonly CondominioContext Db;
        protected readonly DbSet<Condominium> DbSet;
        public CondominiusRepository(CondominioContext condominioContext)
        {
            Db = condominioContext;
            DbSet = Db.Set<Condominium>();
        }
        public void Add(Condominium condominium)
        {
            DbSet.Add(condominium);
        }
        
        public async Task<IEnumerable<Condominium>> GetAll()
        {
            //var lista = DbSet.ToList();
            return await DbSet.ToListAsync();
        }

        public async Task<Condominium> GetById(int CondominiunId)
        {
            return await DbSet.FindAsync(CondominiunId);
        }

        public void Remove(Condominium condominium)
        {
            DbSet.Remove(condominium);
        }

        public void Update(Condominium condominium)
        {
            DbSet.Update(condominium);
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
