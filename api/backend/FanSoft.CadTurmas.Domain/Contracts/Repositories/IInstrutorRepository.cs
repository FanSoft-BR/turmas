using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Domain.Contracts.Repositories
{
    public interface IInstrutorReadRepository : IReadRepository<Instrutor>
    { }

    public interface IInstrutorWriteRepository : IWriteRepository<Instrutor>
    { }
}