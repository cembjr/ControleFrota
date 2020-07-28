using Cembjr.ControleFrota.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cembjr.ControleFrota.Data.Mappings
{
    public class ServicoMapping : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("CFServ");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("IdServ")
                   .IsRequired();

            builder.Property(x => x.Saida)
                   .IsRequired()
                   .HasColumnName("DatSaid");

            builder.Property(x => x.Chegada)
                   .HasColumnName("DatCheg");

            builder.Property(x => x.IdAtendente)
                   .IsRequired()
                   .HasColumnName("IdAten");

            builder.Property(x => x.IdMotorista)
                   .IsRequired()
                   .HasColumnName("IdMoto");

            builder.Property(x => x.IdVeiculo)
                   .IsRequired()
                   .HasColumnName("IdVeic");

            builder.Property(x => x.Destino)
                   .IsRequired()
                   .HasColumnName("ServDest");

            builder.Property(x => x.Observacao)
                   .HasColumnName("ServObse");

            builder.Property(x => x.KmInicial)
                   .IsRequired()
                   .HasColumnName("ServKmInic");

            builder.Property(x => x.KmFinal)
                   .HasColumnName("ServKmFina");

            builder.HasOne(x => x.Atendente)
                   .WithMany(x => x.Servicos)
                   .HasForeignKey(x => x.IdAtendente)
                   .HasPrincipalKey(x => x.Id);

            builder.HasOne(x => x.Motorista)
                   .WithMany(x => x.Servicos)
                   .HasForeignKey(x => x.IdMotorista)
                   .HasPrincipalKey(x => x.Id);

            builder.HasOne(x => x.Veiculo)
                   .WithMany(x => x.Servicos)
                   .HasForeignKey(x => x.IdVeiculo)
                   .HasPrincipalKey(x => x.Id);
        }
    }
}
