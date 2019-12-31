using System.Threading.Tasks;

namespace FanSoft.CadTurmas.Domain.Contracts.Infra.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        Task RollBackAsync();
    }
}