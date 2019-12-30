using System;
using FanSoft.CadTurmas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FanSoft.CadTurmas.Data.EF
{
    public class CadTurmasDataContext : DbContext
    {
        private readonly IConfiguration _config;

        public CadTurmasDataContext(IConfiguration config) => _config = config;
        public CadTurmasDataContext(DbContextOptions options) : base(options){}
        
        public DbSet<Instrutor> Instrutores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        // public DbSet<TurmaInstrutor> TurmasInstrutores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_config != null) optionsBuilder.UseSqlServer(_config.GetConnectionString("CadTurmasConn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new Maps.InstrutorMap());
            modelBuilder.ApplyConfiguration(new Maps.TurmaMap());

            modelBuilder.Entity<Instrutor>().HasData(
                new Instrutor(1,"Fabiano Nalin")
            );

            var turmaId = Guid.NewGuid();

            modelBuilder.Entity<Turma>().HasData(
                new Turma(turmaId, "AZ 203 Dez 2019", "Turma AZ 203")
            );

        }


    }
}