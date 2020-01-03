using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Data.EF.Repositories
{
    public class InstrutorReadRepositoryEF : ReadRepositoryEF<Instrutor>, IInstrutorReadRepository
    {
        public InstrutorReadRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }
    }

    public class InstrutorWriteRepositoryEF : WriteRepositoryEF<Instrutor>, IInstrutorWriteRepository
    {
        public InstrutorWriteRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }
    }
}
