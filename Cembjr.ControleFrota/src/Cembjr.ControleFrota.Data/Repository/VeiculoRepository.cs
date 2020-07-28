using Cembjr.ControleFrota.Business.Entities;
using Cembjr.ControleFrota.Business.Interfaces;
using Cembjr.ControleFrota.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cembjr.ControleFrota.Data.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(ControleFrotaContext db) : base(db)
        {
        }
    }
}
