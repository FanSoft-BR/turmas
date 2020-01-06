using FanSoft.CadTurmas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanSoft.CadTurmas.Data.EF.Maps
{
    public class UsuarioRoleMap : IEntityTypeConfiguration<UsuarioRole>
    {
        public void Configure(EntityTypeBuilder<UsuarioRole> builder)
        {
            builder.ToTable(nameof(UsuarioRole));

            builder.HasKey(pk => new { pk.UsuarioId, pk.RoleId });

            builder.Property(p => p.CriadoEm).HasColumnType("datetime2");
            builder.Property(p => p.AlteradoEm).HasColumnType("datetime2");

            builder
                   .HasOne(p => p.Usuario)
                   .WithMany(p => p.UsuarioRoles)
                   .HasForeignKey(fk => fk.UsuarioId);

            builder
                    .HasOne(p => p.Role)
                    .WithMany(p => p.UsuarioRoles)
                    .HasForeignKey(fk => fk.RoleId);

        }
    }
}
