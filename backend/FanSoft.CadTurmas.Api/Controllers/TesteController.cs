
using Microsoft.AspNetCore.Mvc;

namespace FanSoft.CadTurmas.Api.Controllers
{
    public class TesteController
    {
        
        [HttpGet("api/ping")]
        public string Ping() => "Pong";

    }
}