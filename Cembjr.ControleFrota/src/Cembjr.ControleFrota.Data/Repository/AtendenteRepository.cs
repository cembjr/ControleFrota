using Cembjr.ControleFrota.Business.Entities;
using Cembjr.ControleFrota.Business.Interfaces;
using Cembjr.ControleFrota.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cembjr.ControleFrota.Data.Repository
{
    public class AtendenteRepository : Repository<Atendente>, IAtendenteRepository
    {
        public  AtendenteRepository(ControleFrotaContext db) : base(db)
        {
        }
    }
}
