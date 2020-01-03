using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Domain.Contracts.Repositories
{
    public interface ITurmaReadRepository : IReadRepository<Turma>
    { 
        Task<IEnumerable<Turma>> GetAllWithInstrutorAsync();
        Task<Turma> GetByIdWithInstrutorAsync(Guid id);
    }

    public interface ITurmaWriteRepository : IWriteRepository<Turma>
    { }
}