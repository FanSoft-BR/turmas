using FanSoft.CadTurmas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanSoft.CadTurmas.Data.EF.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(80)");
            builder.Property(p => p.Email).IsRequired().HasColumnType("varchar(80)");
            builder.Property(p => p.Senha).IsRequired().HasColumnType("char(88)");

            builder.Property(p => p.CriadoEm).HasColumnType("datetime2");
            builder.Property(p => p.AlteradoEm).HasColumnType("datetime2");

        }
    }
}