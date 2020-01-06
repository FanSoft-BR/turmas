using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using FanSoft.CadTurmas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FanSoft.CadTurmas.Data.EF.Repositories
{
    public class UsuarioReadRepositoryEF : ReadRepositoryEF<Usuario>, IUsuarioReadRepository
    {
        public UsuarioReadRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }
        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await
                            _db
                                .Include(u => u.UsuarioRoles).ThenInclude(r => r.Role)
                                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Usuario> GetByIdWithRolesAsync(int id)
        {
            return await
                        _db
                            .Include(u => u.UsuarioRoles)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> GetByRefreshTokenAsync(string token)
        {
            return await
                        _db
                            .Include(u => u.UsuarioRoles).ThenInclude(r => r.Role)
                            .FirstOrDefaultAsync(x => x.RefreshToken == token);
        }
    }

    public class UsuarioWriteRepositoryEF : WriteRepositoryEF<Usuario>, IUsuarioWriteRepository
    {
        public UsuarioWriteRepositoryEF(CadTurmasDataContext ctx) : base(ctx) { }

    }
}
