using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cembjr.ControleFrota.UI.ViewModels
{
    public class VeiculoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres", MinimumLength = 7)]
        public string Placa { get; set; }
    }
}
