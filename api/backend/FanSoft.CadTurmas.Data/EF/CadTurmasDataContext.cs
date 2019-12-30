using FanSoft.CadTurmas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FanSoft.CadTurmas.Data.EF
{
    public class CadTurmasDataContext : DbContext
    {
        public DbSet<Turma> Turmas { get; set; }
    }
}