using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Data.EF.Repositories
{
    public class RoleReadRepositoryEF : ReadRepositoryEF<Role>, IRoleReadRepository
    {
        public RoleReadRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }
    }

    public class RoleWriteRepositoryEF : WriteRepositoryEF<Role>, IRoleWriteRepository
    {
        public RoleWriteRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }
    }
}