using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Data.EF.Repositories
{
    public class UsuarioReadRepositoryEF : ReadRepositoryEF<Usuario>, IUsuarioReadRepository
    {
        public UsuarioReadRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }
    }

    public class UsuarioWriteRepositoryEF : WriteRepositoryEF<Usuario>, IUsuarioWriteRepository
    {
        public UsuarioWriteRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }
    }
}
