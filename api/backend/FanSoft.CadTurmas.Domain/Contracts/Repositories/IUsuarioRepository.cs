using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Domain.Contracts.Repositories
{
    public interface IUsuarioReadRepository : IReadRepository<Usuario>
    { }

    public interface IUsuarioWriteRepository : IWriteRepository<Usuario>
    { }
}