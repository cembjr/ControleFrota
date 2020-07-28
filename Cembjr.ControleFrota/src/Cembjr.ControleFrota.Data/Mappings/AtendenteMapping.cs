using Cembjr.ControleFrota.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cembjr.ControleFrota.Data.Mappings
{
    public class AtendenteMapping : IEntityTypeConfiguration<Atendente>
    {
        public void Configure(EntityTypeBuilder<Atendente> builder)
        {
            builder.ToTable("CFAten");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("IdAten")
                   .IsRequired();

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasColumnName("AtenNome");

            builder.Property(x => x.Telefone)
                   .IsRequired()
                   .HasColumnName("AtenTele");
        }
    }
}
