using FanSoft.CadTurmas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanSoft.CadTurmas.Data.EF.Maps
{
    public class InstrutorMap : IEntityTypeConfiguration<Instrutor>
    {
        public void Configure(EntityTypeBuilder<Instrutor> builder)
        {
            builder.HasKey(pk => pk.Id);

        }
    }
}