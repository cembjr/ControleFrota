using Cembjr.ControleFrota.Business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cembjr.ControleFrota.Data.Context
{
    public class ControleFrotaContext : DbContext
    {
        public ControleFrotaContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Atendente> Atendentes { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Servico> Servicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControleFrotaContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity.GetType().GetProperty("DataCadastro") != null)
                {
                    if (entry.State == EntityState.Added)
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                    if (entry.State == EntityState.Modified)
                        entry.Property("DataCadastro").IsModified = false;
                }

                if (entry.State == EntityState.Added) entry.Property("IsExcluido").CurrentValue = false;
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
