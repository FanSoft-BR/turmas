using FanSoft.CadTurmas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanSoft.CadTurmas.Data.EF.Maps
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(80)");
            builder.Property(p => p.Descricao).HasColumnType("varchar(80)");

            builder.Property(p => p.CriadoEm).HasColumnType("datetime2");
            builder.Property(p => p.AlteradoEm).HasColumnType("datetime2");

        }
    }
}
