using System;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Infra.Data;

namespace FanSoft.CadTurmas.Data.EF
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly CadTurmasDataContext _ctx;
        public UnitOfWorkEF(CadTurmasDataContext ctx) => _ctx = ctx;

        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public Task RollBackAsync()
        {
            throw new NotImplementedException();
        }
    }
}