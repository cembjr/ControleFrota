using System;
using System.Collections.Generic;
using System.Text;

namespace Cembjr.ControleFrota.Business.Entities
{
    public class Veiculo : Entity
    {
        public Veiculo(string marca, string modelo, string placa)
        {
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
        }

        public Veiculo()
        {

        }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Placa { get; set; }

        public virtual IEnumerable<Servico> Servicos { get; set; }

        public Veiculo Atualizar(string marca, string modelo, string placa)
        {
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            return this;
        }

    }
}
