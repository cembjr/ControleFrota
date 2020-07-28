using System;
using System.Collections.Generic;
using System.Text;

namespace Cembjr.ControleFrota.Business.Entities
{
    public class Atendente : Entity
    {
        public Atendente(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }

        public Atendente()
        {

        }

        public string Nome { get; set; }
        public string Telefone { get; set; }

        public virtual IEnumerable<Servico> Servicos { get; set; }

        public Atendente Atualizar(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;

            return this;
        }
    }
}
