using System;
using System.Collections.Generic;
using System.Text;
using Cembjr.ControleFrota.UI.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControleFrota.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AtendenteViewModel> Atendentes { get; set; }
        public DbSet<VeiculoViewModel> Veiculos { get; set; }
        public DbSet<ServicoViewModel> Servicos { get; set; }
        public DbSet<MotoristaViewModel> Motoristas { get; set; }

    }
}
