using System;
using System.Collections.Generic;
using System.Text;

namespace Cembjr.ControleFrota.Business.Entities
{
    public class Motorista : Entity
    {
        public Motorista(string nome, string telefone, string cnh)
        {
            Nome = nome;
            Telefone = telefone;
            Cnh = cnh;
        }
        public Motorista()
        {

        }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cnh { get; set; }

        public virtual IEnumerable<Servico> Servicos { get; set; }
        public Motorista Atualizar(string nome, string telefone, string cnh)
        {
            Nome = nome;
            Telefone = telefone;
            Cnh = cnh;
            return this;
        }
    }
}
