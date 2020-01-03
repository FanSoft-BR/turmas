using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using FanSoft.CadTurmas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FanSoft.CadTurmas.Data.EF.Repositories
{
    public class TurmaReadRepositoryEF : ReadRepositoryEF<Turma>, ITurmaReadRepository
    {
        public TurmaReadRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Turma>> GetAllWithInstrutorAsync()
        {
            return await _db.Include(t=>t.Instrutor).AsNoTracking().ToListAsync();
        }

        public async Task<Turma> GetByIdWithInstrutorAsync(Guid id)
        {
            return await _db.Include(t=>t.Instrutor).AsNoTracking().FirstOrDefaultAsync(t=>t.Id == id);
        }
    }

    public class TurmaWriteRepositoryEF : WriteRepositoryEF<Turma>, ITurmaWriteRepository
    {
        public TurmaWriteRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }
    }
}