using Cembjr.ControleFrota.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cembjr.ControleFrota.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity obj);
        Task Atualizar(TEntity obj);
        Task Deletar(Guid id);
        Task<TEntity> Obter(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ListarTodos();
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
        Task<bool> SaveChanges();
    }
}
