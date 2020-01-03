using FanSoft.CadTurmas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanSoft.CadTurmas.Data.EF.Maps
{
    public class InstrutorMap : IEntityTypeConfiguration<Instrutor>
    {
        public void Configure(EntityTypeBuilder<Instrutor> builder)
        {
            builder.ToTable(nameof(Instrutor));

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(80)");
            builder.Property(p => p.Descricao).HasColumnType("varchar(80)");

            builder.Property(p => p.CriadoEm).HasColumnType("datetime2");
            builder.Property(p => p.AlteradoEm).HasColumnType("datetime2");

        }
    }
}