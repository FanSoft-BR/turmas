using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Domain.Contracts.Repositories
{
    public interface IUsuarioReadRepository : IReadRepository<Usuario>
    {
        Task<Usuario> GetByEmailAsync(string email);
        Task<Usuario> GetByRefreshTokenAsync(string token);
        Task<Usuario> GetByIdWithRolesAsync(int id);
    }

    public interface IUsuarioWriteRepository : IWriteRepository<Usuario>
    {}
}