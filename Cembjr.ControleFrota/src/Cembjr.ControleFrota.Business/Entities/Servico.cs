using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cembjr.ControleFrota.Business.Entities
{
    public class Servico : Entity
    {
        public Servico(DateTime saida, DateTime? chegada, Guid idAtendente, Guid idMotorista, Guid idVeiculo, string destino, string observacao, int kmInicial, int? kmFinal)
        {
            Saida = saida;
            Chegada = chegada;
            IdAtendente = idAtendente;
            IdMotorista = idMotorista;
            IdVeiculo = idVeiculo;
            Destino = destino;
            Observacao = observacao;
            KmInicial = kmInicial;
            KmFinal = kmFinal;
        }

        public Servico()
        {

        }

        public DateTime Saida { get; set; }
        public DateTime? Chegada { get; set; }
        public Guid IdAtendente { get; set; }
        public Guid IdMotorista { get; set; }
        public Guid IdVeiculo { get; set; }
        public string Destino { get; set; }
        public string Observacao { get; set; }
        public int KmInicial { get; set; }
        public int? KmFinal { get; set; }

        public virtual Atendente Atendente { get; set; }
        public virtual Motorista Motorista { get; set; }
        public virtual Veiculo Veiculo { get; set; }

        public Servico Atualizar(DateTime saida, DateTime? chegada, string destino, string observacao, int kmInicial, int? kmFinal)
        {
            Saida = saida;
            Chegada = chegada;            
            Destino = destino;
            Observacao = observacao;
            KmInicial = kmInicial;
            KmFinal = kmFinal;
            return this;
        }

        public bool IsViagemEmAberto { get { return !Chegada.HasValue; } }

    }
}
