using System.Collections.Generic;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Entities;

namespace FanSoft.CadTurmas.Domain.Contracts.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> Get();
        TEntity Get(object id);

        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(object id);
    }

    public interface IWriteRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}