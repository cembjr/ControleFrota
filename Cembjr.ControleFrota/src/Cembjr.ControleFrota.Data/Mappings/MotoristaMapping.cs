using Cembjr.ControleFrota.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cembjr.ControleFrota.Data.Mappings
{
    public class MotoristaMapping : IEntityTypeConfiguration<Motorista>
    {
        public void Configure(EntityTypeBuilder<Motorista> builder)
        {
            builder.ToTable("CFMoto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("IdMoto")
                   .IsRequired();

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasColumnName("MotoNome");

            builder.Property(x => x.Telefone)
                   .IsRequired()
                   .HasColumnName("MotoTele");

            builder.Property(x => x.Cnh)
                   .IsRequired()
                   .HasColumnName("MotoCnh");
        }
    }
}
