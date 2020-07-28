using System;
using System.Collections.Generic;
using System.Text;

namespace Cembjr.ControleFrota.Business.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; protected set; }
        public bool IsExcluido { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public void Excluir()
        {
            IsExcluido = true;
        }
    }
}
