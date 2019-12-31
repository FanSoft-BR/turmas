using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FanSoft.CadTurmas.Api.Controllers
{
    [Route("api/v1/{controller}")]
    public class TurmasController : Controller
    {
        private readonly ITurmaReadRepository _turmaReadRepository;

        public TurmasController(ITurmaReadRepository turmaReadRepository)
        {
            _turmaReadRepository = turmaReadRepository;
        }

        public async Task<IActionResult> GetAll()
        {
            var turmas = await _turmaReadRepository.GetAsync();
            return Ok(turmas);
        }

    }
}