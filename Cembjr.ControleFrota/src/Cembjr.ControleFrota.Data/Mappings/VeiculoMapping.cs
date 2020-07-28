using Cembjr.ControleFrota.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cembjr.ControleFrota.Data.Mappings
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("CFVeic");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("IdVeic")
                   .IsRequired();

            builder.Property(x => x.Marca)
                   .IsRequired()
                   .HasColumnName("VeicMarc");

            builder.Property(x => x.Modelo)
                   .IsRequired()
                   .HasColumnName("VeicMode");

            builder.Property(x => x.Placa)
                   .IsRequired()
                   .HasColumnName("VeicPlac");
        }
    }
}
