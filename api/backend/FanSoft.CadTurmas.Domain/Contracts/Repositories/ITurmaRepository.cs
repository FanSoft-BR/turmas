using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Domain.Contracts.Repositories
{
    public interface ITurmaReadRepository : IReadRepository<Turma>
    { }

    public interface ITurmaWriteRepository : IWriteRepository<Turma>
    { }
}