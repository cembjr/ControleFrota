using Cembjr.ControleFrota.Business.Entities;
using Cembjr.ControleFrota.Business.Interfaces;
using Cembjr.ControleFrota.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cembjr.ControleFrota.Data.Repository
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(ControleFrotaContext db) : base(db)
        {
        }

        public override async Task<IEnumerable<Servico>> ListarTodos()
        {
            return await Query().Include(x => x.Motorista).Include(x => x.Atendente).Include(x => x.Veiculo).ToListAsync();
        }
    }
}
