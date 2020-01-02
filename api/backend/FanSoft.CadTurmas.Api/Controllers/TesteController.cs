
using Microsoft.AspNetCore.Mvc;

namespace FanSoft.CadTurmas.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class TesteController
    {
         /// <summary>
        /// Testa a conectividade
        /// </summary>
        /// <returns>Uma string</returns>
        /// <response code="200">Houve conectividade</response>
        [HttpGet("ping")]
        public string Ping() => "Pong";

    }
}