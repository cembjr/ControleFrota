using AutoMapper;
using Cembjr.ControleFrota.Business.Entities;
using Cembjr.ControleFrota.UI.ViewModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cembjr.ControleFrota.UI.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AtendenteViewModel, Atendente>().ReverseMap();
            CreateMap<VeiculoViewModel, Veiculo>().ReverseMap();
            CreateMap<ServicoViewModel, Servico>().ReverseMap();
            CreateMap<MotoristaViewModel, Motorista>().ReverseMap();
        }
    }
}
