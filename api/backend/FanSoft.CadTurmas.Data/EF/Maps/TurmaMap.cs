using FanSoft.CadTurmas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanSoft.CadTurmas.Data.EF.Maps
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable(nameof(Turma));

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(80)");
            builder.Property(p => p.Descricao).HasColumnType("varchar(80)");
            builder.Property(p => p.InstrutorId).HasColumnType("int");

            builder.Property(p => p.DataInicio).HasColumnType("date");
            builder.Property(p => p.DataTermino).HasColumnType("date");

            builder.Property(p => p.CriadoEm).HasColumnType("datetime2");
            builder.Property(p => p.AlteradoEm).HasColumnType("datetime2");

            builder.HasOne(c=>c.Instrutor).WithMany(c=>c.Turmas).HasForeignKey(fk=>fk.InstrutorId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}