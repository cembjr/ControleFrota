using Cembjr.ControleFrota.Business.Entities;
using Cembjr.ControleFrota.Business.Interfaces;
using Cembjr.ControleFrota.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cembjr.ControleFrota.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {

        protected readonly ControleFrotaContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ControleFrotaContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
            await SaveChanges();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(x => !x.IsExcluido).Where(predicate).ToListAsync();
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null)
        {            
            return predicate == null ? DbSet.AsNoTracking().Where(x => !x.IsExcluido) : DbSet.AsNoTracking().Where(x => !x.IsExcluido).Where(predicate);
        }

        public virtual async Task Deletar(Guid id)
        {
            var obj = DbSet.Find(id);

            obj.Excluir();
            
            await Atualizar(obj);

            await SaveChanges();
        }

        public virtual async Task<IEnumerable<TEntity>> ListarTodos()
        {
            return await DbSet.Where(x => !x.IsExcluido).ToListAsync();
        }

        public virtual async Task<TEntity> Obter(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(x => !x.IsExcluido).FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.Where(x => !x.IsExcluido).FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<bool> SaveChanges()
        {
            return await Db.SaveChangesAsync() > 0;
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
