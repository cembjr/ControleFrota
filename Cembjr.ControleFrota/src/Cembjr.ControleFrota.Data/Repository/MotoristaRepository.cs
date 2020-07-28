using Cembjr.ControleFrota.Business.Entities;
using Cembjr.ControleFrota.Business.Interfaces;
using Cembjr.ControleFrota.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cembjr.ControleFrota.Data.Repository
{
    public class MotoristaRepository : Repository<Motorista>, IMotoristaRepository
    {
        public MotoristaRepository(ControleFrotaContext db) : base(db)
        {
        }
    }
}
