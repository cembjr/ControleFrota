using Cembjr.ControleFrota.Business.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cembjr.ControleFrota.UI.ViewModels
{
    public class ServicoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Saida { get; set; }
        
        public DateTime? Chegada { get; set; }

        [HiddenInput]
        [DisplayName("Atendente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]        
        public Guid IdAtendente { get; set; }
        
        [HiddenInput]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Motorista")]
        public Guid IdMotorista { get; set; }
        
        [HiddenInput]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Veiculo")]
        public Guid IdVeiculo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Destino { get; set; }
        
        public string Observacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int KmInicial { get; set; }
        
        public int? KmFinal { get; set; }

        public AtendenteViewModel Atendente { get; set; }

        public MotoristaViewModel Motorista { get; set; }

        public VeiculoViewModel Veiculo { get; set; }

        public IEnumerable<AtendenteViewModel> Atendentes { get; set; }
        public IEnumerable<MotoristaViewModel> Motoristas { get; set; }
        public IEnumerable<VeiculoViewModel> Veiculos { get; set; }
    }
}
