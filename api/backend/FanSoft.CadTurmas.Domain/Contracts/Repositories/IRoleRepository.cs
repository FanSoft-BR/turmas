using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Domain.Contracts.Repositories
{

    public interface IRoleReadRepository : IReadRepository<Role>
    { }

    public interface IRoleWriteRepository : IWriteRepository<Role>
    { }
}