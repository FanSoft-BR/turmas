using System;
using FanSoft.CadTurmas.Domain.Entities;
using FanSoft.CadTurmas.Domain.Infra.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FanSoft.CadTurmas.Data.EF
{
    public class CadTurmasDataContext : DbContext
    {
        private readonly IConfiguration _config;

        public CadTurmasDataContext(IConfiguration config) => _config = config;
        public CadTurmasDataContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_config != null) optionsBuilder.UseSqlServer(_config.GetConnectionString("CadTurmasConn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new Maps.InstrutorMap());
            modelBuilder.ApplyConfiguration(new Maps.TurmaMap());
            modelBuilder.ApplyConfiguration(new Maps.UsuarioMap());

            modelBuilder.Entity<Instrutor>().HasData(
                new Instrutor(1, "Fabiano Nalin")
            );

            var turmaId = Guid.NewGuid();

            modelBuilder.Entity<Turma>().HasData(
                new Turma(turmaId, "AZ 203 Dez 2019", DateTime.UtcNow.Date, DateTime.UtcNow.Date.AddDays(14), 1, "Turma AZ 203")
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario(1, "Fabiano Nalin","nalin@fansoft.com.br", "123456".Encrypt())
            );

        }


    }
}