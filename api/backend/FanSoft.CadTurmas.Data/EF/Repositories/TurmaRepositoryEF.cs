using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Data.EF.Repositories
{
    public class TurmaReadRepositoryEF : ReadRepositoryEF<Turma>, ITurmaReadRepository
    {
        public TurmaReadRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }
    }

    public class TurmaWriteRepositoryEF : WriteRepositoryEF<Turma>, ITurmaWriteRepository
    {
        public TurmaWriteRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }
    }
}